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

        var records = _context.Animes.Join(_context.AnimesStudios, x => x.MyAnimeListId, y => y.AnimeId, (anime, studio) => new { anime, studio })
                      .Join(_context.Studios, x => x.studio.StudioId, y => y.StudioName, (animestudio, studio) => new
                      {
                          studio.StudioName,
                          animestudio.anime.StartDateAired
                      })
                      .Where(a => !request.Ano.HasValue ? true : (a.StartDateAired.HasValue && a.StartDateAired.Value.Year == request.Ano))
                      .Where(a => !request.Mes.HasValue ? true : (a.StartDateAired.HasValue && a.StartDateAired.Value.Month == request.Mes))
                      .GroupBy(a => a.StudioName).Select(a => new AnimePerStudioPeriod
                      {
                          Studio = a.Key,
                          QtdReleased = a.Count(),
                          Anos = a.Min(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Year : 9999)).ToString() + " a " + a.Max(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Year : 0)).ToString(),
                          Meses = a.Min(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Month : 12)).ToString() + " a " + a.Max(a => (a.StartDateAired.HasValue ? a.StartDateAired.Value.Month : 0)).ToString()
                      });

        var total = await records.CountAsync(cancellationToken);
        var items = await records.PaginateByDescending(request, d => d.QtdReleased).ToListAsync(cancellationToken);



        return new PageResult<AnimePerStudioPeriod>(request, total, items);



    }
}


