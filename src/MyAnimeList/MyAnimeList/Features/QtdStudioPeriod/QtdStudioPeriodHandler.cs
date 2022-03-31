using MediatR;
using Nudes.Retornator.Core;
using Nudes.Paginator.Core;
using MyAnimeList.Models;
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

    public static string PreparaData(Match m)
    {
        return (m.Groups["month"].Success ? m.Groups["month"].Value + " " : "Jan ") +
            (m.Groups["day"].Success ? m.Groups["day"].Value + ", " : " 1, ") +
            (m.Groups["year"].Value);
    }

    public Task<ResultOf<PageResult<AnimePerStudioPeriod>>> Handle(QtdStudioPeriodRequest request, CancellationToken cancellationToken)
    {


        MatchEvaluator evaluator = new MatchEvaluator(PreparaData);


        var records = _context.Animes.AsEnumerable()
            .Where(a => a.Studios != null)
            .Where(a => a.Aired != null)
            .Select(a => new
            {
                studio = a.Studios,
                date = DateTime.Parse(PreparaData(Regex.Match(a.Aired, @"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?<day>\d{1,2}\D)*[\.,\s]*\D*(?<year>\d{4})")),
                    new System.Globalization.CultureInfo("en-US")),
            }).GroupBy(a => new { a.studio, a.date.Month, a.date.Year })
            .Select(a => new
            {
                studio = a.Key.studio,
                month = a.Key.Month,
                year = a.Key.Year,
                count = a.Count()
            });
          

        foreach (var record in records)
        {
            Console.WriteLine(record.studio + " " + record.count);
        }


        return null;
    }

}


