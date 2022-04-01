using MediatR;
using Nudes.Retornator.Core;
using Nudes.Paginator.Core;
using MyAnimeList.Models;
using MyAnimeList.Domain;

using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodHandler : IRequestHandler<QtdStudioPeriodRequest, ResultOf<PageResult<AnimePerStudioPeriod>>>
{
    private readonly MyAnimeListContext _context;
    public QtdStudioPeriodHandler(MyAnimeListContext context)
    {
        _context = context;
    }

    public async Task<ResultOf<PageResult<AnimePerStudioPeriod>>> Handle(QtdStudioPeriodRequest request, CancellationToken cancellationToken)
    {

        var records = _context.Studios.Join(_context.Animes, a => a.MyAnimeListId, b => b.MyAnimeListId, (a, b) => new
        {
            a.StudioName,
            b.StartDateAired
        })
            .Where( a => !request.ano.HasValue ? true : (a.StartDateAired.HasValue && a.StartDateAired.Value.Year == request.ano) )
            .Where( a => !request.mes.HasValue ? true : (a.StartDateAired.HasValue && a.StartDateAired.Value.Month == request.mes))
            .GroupBy(a => a.StudioName).Select(a => new AnimePerStudioPeriod
        {
            Studio = a.Key,
            QtdReleased = a.Count(),
            anos = a.Min(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Year : 9999)).ToString() + " a " + a.Max(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Year : 0)).ToString(),
            meses = a.Min(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Month : 12)).ToString() + " a "+a.Max(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Month : 0)).ToString()
        });

        var total = await records.CountAsync(cancellationToken);
        var items = await records.PaginateByDescending(request, d => d.QtdReleased).ToListAsync(cancellationToken);



        return new PageResult<AnimePerStudioPeriod>(request, total, items);



    }
}


