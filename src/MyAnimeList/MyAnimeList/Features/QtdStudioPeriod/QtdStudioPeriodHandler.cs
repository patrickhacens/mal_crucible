using MediatR;
using Nudes.Retornator.Core;
using Nudes.Paginator.Core;
using MyAnimeList.DTO;
using MyAnimeList.Domain;
using System.Text.RegularExpressions;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodHandler : IRequestHandler<QtdStudioPeriodRequest, ResultOf<PageResult<AnimePerStudioPeriod>>>
{
    private readonly MyAnimeListContext _context;
    public QtdStudioPeriodHandler(MyAnimeListContext context)
    {
        _context = context;
    }

    public Task<ResultOf<PageResult<AnimePerStudioPeriod>>> Handle(QtdStudioPeriodRequest request, CancellationToken cancellationToken)
    {

        var records = _context.Animes
            .Where(a => Regex.IsMatch(a.Aired, @"(?i)^\s*(?<month>jan|feb|mar|abr|may|jun|jul|ago|sep|oct|nov|dec)[\.,\s]*\D*(?<day>\d+)[\.,\s]*\D*(?<year>\d{4})"))
            .Select(a => new
            {
                date = Regex.Replace(a.Aired,
            @"(?i)^\s*(?<month>jan|feb|mar|abr|may|jun|jul|ago|sep|oct|nov|dec)[\.,\s]*\D*(?<day>\d+)[\.,\s]*\D*(?<year>\d{4})",
            @"Shimoo=${month} ${day}, ${year}")
            });
        foreach (var record in records)
        {
            Console.WriteLine(record.date);
        }


        return null;
    }
}


