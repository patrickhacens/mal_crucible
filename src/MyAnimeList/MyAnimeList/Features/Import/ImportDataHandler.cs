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
            IEnumerable<AnimeRaw> records = csv.GetRecords<AnimeRaw>();

            List<Genre> genres = new();

            foreach (var record in records)
            {
                var anime = record.Adapt<Anime>();
                #region GetAiredDates
                if (anime.Aired != null)
                {
                    Match mDates = Regex.Match(anime.Aired, @"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?:(?<day>\d{1,2})\D)*[\.,\s]*\D*(?<year>\d{4})(?:\s*to\s*(?<monthto>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*(?:(?<dayto>\d{1,2})\D)*\D*(?<yearto>\d{4})*)*");
                    String sDateFrom = (mDates.Groups["month"].Success ? mDates.Groups["month"].Value : "Jan") + " " +
                                       (mDates.Groups["day"].Success ? mDates.Groups["day"].Value : "1") + ", " +
                                       mDates.Groups["year"].Value;
                    anime.StartDateAired = DateTime.Parse(sDateFrom, new System.Globalization.CultureInfo("en-US"));
                    if (mDates.Groups["yearto"].Success)
                    {
                        String sDateTo = (mDates.Groups["monthto"].Success ? mDates.Groups["monthto"].Value : "Jan") + " " +
                                       (mDates.Groups["dayto"].Success ? mDates.Groups["dayto"].Value : "1") + ", " +
                                       mDates.Groups["yearto"].Value;
                        anime.EndDateAired = DateTime.Parse(sDateTo, new System.Globalization.CultureInfo("en-US"));
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


                #region InsertStudios
                if (anime.Studios != null)
                {
                    string[] Studios = anime.Studios.Split(",");
                    foreach (string Studio in Studios)
                    {
                        var studio = new Studio();
                        studio.MyAnimeListId = anime.MyAnimeListId;
                        studio.StudioName = Studio.Trim();
                        _context.Studios.Add(studio);
                    }
                }
                #endregion






                _context.Animes.Add(anime);
                if (record.Genres != null)
                {
                    foreach (string genreSplited in record.Genres.Split(',').Select(d => d.Trim()))
                    {
                        if (!genres.Any(g => g.Name == genreSplited))
                        {
                            var newGenre = new Genre() { Name = genreSplited };

                            genres.Add(newGenre);

                            _context.Genres.Add(newGenre);

                            _context.AnimeGenres.Add(new AnimeGenres()
                            {
                                Genre = newGenre,
                                Anime = anime
                            });
                        }

                        else
                        {
                            var genre = genres.FirstOrDefault(g => g.Name == genreSplited);

                            _context.AnimeGenres.Add(new AnimeGenres()
                            {
                                Genre = genre,
                                Anime = anime
                            });
                        }
                    }
                }
            }
        }
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
