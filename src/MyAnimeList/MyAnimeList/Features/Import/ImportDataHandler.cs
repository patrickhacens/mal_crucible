using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using MyAnimeList.Domain;
using MyAnimeList.Domain.CsvDomain;
using Nudes.Retornator.Core;
using System.Text;
using Mapster;
using System.Text.RegularExpressions;

namespace MyAnimeList.Features.Import;

public class ImportDataHandler : IRequestHandler<ImportDataRequest, Result>
{
    private readonly MyAnimeListContext _context;
    public ImportDataHandler(MyAnimeListContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(ImportDataRequest request, CancellationToken cancellationToken)
    {
        var config = new CsvConfiguration(new System.Globalization.CultureInfo("en-US")) { Delimiter = "," };

        if (request.PathToRawFolder == "string") request.PathToRawFolder = "..\\..\\..\\RawData";
        var path = request.PathToRawFolder;


        if (!File.Exists(Path.Combine(request.PathToRawFolder, "animelist.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "anime.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "anime_with_synopsis.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "rating_complete.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "watching_status.csv")))
        {
            return new Nudes.Retornator.AspnetCore.Errors.NotFoundError();
        }

        #region CleanDb
        _context.AnimeScores.RemoveRange(_context.AnimeScores.Select(a => a));
        _context.AnimeGenres.RemoveRange(_context.AnimeGenres.Select(a => a));
        _context.Genres.RemoveRange(_context.Genres.Select(a => a));
        _context.Studios.RemoveRange(_context.Studios.Select(a => a));
        _context.Animes.RemoveRange(_context.Animes.Select(a => a));
        _context.AnimesWithSynopsis.RemoveRange(_context.AnimesWithSynopsis.Select(a => a));
        _context.RatingCompletes.RemoveRange(_context.RatingCompletes.Select(a => a));
        _context.WatchStatus.RemoveRange(_context.WatchStatus.Select(a => a));
        await _context.SaveChangesAsync(cancellationToken);
        #endregion



        #region AnimeScores
        using (var reader = new StreamReader(Path.Combine(path, "animelist.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            IEnumerable<AnimeList> records = csv.GetRecords<AnimeList>();

            _context.AddRange(records.Select(anime => new AnimeScore
            {
                MyAnimeListId = anime.anime_id,
                Score = anime.rating,
                WatchedEpisodes = anime.watched_episodes,
                WatchingStatus = anime.watching_status,
                UserId = anime.user_id
            }));
        }
        #endregion

        #region Animes
        using (var reader = new StreamReader(Path.Combine(path, "anime.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<AnimeMap>();
            List<AnimeRaw> records = csv.GetRecords<AnimeRaw>().ToList();

            var dateregex = new Regex(@"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?:(?<day>\d{1,2})\D)*[\.,\s]*\D*(?<year>\d{4})(?:\s*to\s*(?<monthto>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*(?:(?<dayto>\d{1,2})\D)*\D*(?<yearto>\d{4})*)*");
            Dictionary<string, int> monthmap = new Dictionary<string, int>()
                {
                    {"jan", 1 },
                    {"feb", 2 },
                    {"mar", 3 },
                    {"apr", 4 },
                    {"may", 5 },
                    {"jun", 6 },
                    {"jul", 7 },
                    {"aug", 8 },
                    {"sep", 9 },
                    {"oct", 10 },
                    {"nov", 11 },
                    {"dec", 12 }
                };



            foreach (var record in records)
            {
                var anime = record.Adapt<Anime>();


                #region GetAiredDates
                if (anime.Aired != null)
                {
                    Match mDates = dateregex.Match(anime.Aired);
                    int month = monthmap[mDates.Groups["month"].Success ? mDates.Groups["month"].Value.ToLower() : "jan"];
                    int day = mDates.Groups["day"].Success ? int.Parse(mDates.Groups["day"].Value) : 1;
                    int year = int.Parse(mDates.Groups["year"].Value);
                    anime.StartDateAired = new DateTime(year, month, day);

                    if (mDates.Groups["yearto"].Success)
                    {
                        int monthto = monthmap[mDates.Groups["monthto"].Success ? mDates.Groups["monthto"].Value.ToLower() : "jan"];
                        int dayto = mDates.Groups["dayto"].Success ? int.Parse(mDates.Groups["dayto"].Value) : 1;
                        int yearto = int.Parse(mDates.Groups["yearto"].Value);
                        anime.EndDateAired = new DateTime(yearto, monthto, dayto);
                    }
                    else
                    {
                        anime.EndDateAired = null;
                    }
                }
                else
                {
                    anime.StartDateAired = null;
                    anime.EndDateAired = null;
                }
                #endregion
                _context.Animes.Add(anime);
            }




            #region NewStudio

            

            var normalizedData = records
                      .Where(x => x.Studios != null)
                      .Select(x => x.Studios.Split(",").Select(d => d.ToUpper()))
                      .SelectMany(d => d)
                      .Distinct()
                      .Select(x => new Studio()
                      {
                          StudioName = x
                      })
                      .ToArray();
            _context.Studios.AddRange(normalizedData);

            var data = records
                      .Where(x => x.Studios != null)
                      .Select(x => new {
                          Studios = x.Studios,
                          MyAnimeListId = x.MyAnimeListId
                      }).ToArray();

            var animestudios = from x in _context.Studios.Local.ToList()
                               from y in data.Where(h => h.Studios.ToUpper().Contains(x.StudioName))
                               select new AnimeStudio
                               {
                                   AnimeId = y.MyAnimeListId,
                                   StudioId = x.StudioName
                               };

            _context.AnimesStudios.AddRange(animestudios);
            #endregion

            #region genres


            var data2 = records
                        .Where(x => x.Genres != null)
                        .Select(x => new
                        {
                            Genres = x.Genres,
                            MyAnimeListId = x.MyAnimeListId
                        });

            var datadistinct = data2
                .Select(x => x.Genres.Split(","))
                .SelectMany(y => y)
                .Distinct()
                .Select(x => new Genre()
                {
                    Name = x
                })
                .ToArray();
            _context.Genres.AddRange(datadistinct);

            var genresstudios = from x in _context.Genres.Local.ToList()
                                from y in data2.Where(h => h.Genres.Contains(x.Name))
                                select new AnimeGenres
                                {
                                    GenreName = x.Name,
                                    AnimeId = y.MyAnimeListId
                                };

            _context.AnimeGenres.AddRange(genresstudios);



        }
        #endregion
        #endregion

        #region AnimeWithSynopsis
        using (var reader = new StreamReader(Path.Combine(path, "anime_with_synopsis.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<AnimeWithSynopsisMap>();
            IEnumerable<AnimeWithSynopsisCsv> records = csv.GetRecords<AnimeWithSynopsisCsv>();
            _context.AddRange(records.Adapt<IEnumerable<AnimeWithSynopsis>>());
        }
        #endregion

        #region RatingFromComplete
        using (var reader = new StreamReader(Path.Combine(path, "rating_complete.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<RatingFromCompleteMap>();
            IEnumerable<RatingFromCompleteCsv> records = csv.GetRecords<RatingFromCompleteCsv>();
            _context.AddRange(records.Adapt<IEnumerable<RatingFromComplete>>());
        }
        #endregion

        #region WatchStatus
        using (var reader = new StreamReader(Path.Combine(path, "watching_status.csv")))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<WatchStatusMap>();
            IEnumerable<WatchStatusCsv> records = csv.GetRecords<WatchStatusCsv>();
            _context.AddRange(records.Adapt<IEnumerable<WatchStatus>>());
        }
        #endregion

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }

}