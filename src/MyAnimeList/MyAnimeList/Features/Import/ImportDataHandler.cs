using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using MyAnimeList.Domain;
using MyAnimeList.Domain.CsvDomain;
using Nudes.Retornator.Core;
using System.Text;
using Mapster;


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


        if (!File.Exists(Path.Combine(request.PathToRawFolder,"animelist.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder,"anime.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "anime_with_synopsis.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "rating_complete.csv"))
            || !File.Exists(Path.Combine(request.PathToRawFolder, "watching_status.csv")))
        {
            return new Nudes.Retornator.AspnetCore.Errors.NotFoundError();
        }

        #region AnimeScores
        _context.RemoveRange(_context.AnimeScores.Select(a => a));
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
        _context.RemoveRange(_context.Animes.Select(a => a));
        using (var reader = new StreamReader(Path.Combine(path,"anime.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<AnimeMap>();
            IEnumerable<AnimeRaw> records = csv.GetRecords<AnimeRaw>();
            _context.AddRange(records.Adapt<IEnumerable<Anime>>());

        }
        #endregion

        #region AnimeWithSynopsis
        _context.RemoveRange(_context.AnimesWithSynopsis.Select(a => a));
        using (var reader = new StreamReader(Path.Combine(path,"anime_with_synopsis.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<AnimeWithSynopsisMap>();
            IEnumerable<AnimeWithSynopsisCsv> records = csv.GetRecords<AnimeWithSynopsisCsv>();
            _context.AddRange(records.Adapt<IEnumerable<AnimeWithSynopsis>>());
        }
        #endregion

        #region RatingFromComplete
        _context.RemoveRange(_context.RatingCompletes.Select(a => a));
        using (var reader = new StreamReader(Path.Combine(path,"rating_complete.csv"), Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<RatingFromCompleteMap>();
            IEnumerable<RatingFromCompleteCsv> records = csv.GetRecords<RatingFromCompleteCsv>();
            _context.AddRange(records.Adapt<IEnumerable<RatingFromComplete>>());
        }
        #endregion

        #region WatchStatus
        _context.RemoveRange(_context.WatchStatus.Select(a => a));
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
