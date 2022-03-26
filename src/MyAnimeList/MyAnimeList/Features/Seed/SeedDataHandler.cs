﻿using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using MyAnimeList.Domain;
using MyAnimeList.Domain.CsvDomain;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace MyAnimeList.Features.Seed;

public class SeedDataHandler : IRequestHandler<SeedDataRequest, ResultOf<bool>>
{
    private readonly MyAnimeListContext _context;
    public SeedDataHandler(MyAnimeListContext context)
    {
        _context = context;
    }

    public async Task<ResultOf<bool>> Handle(SeedDataRequest request, CancellationToken cancellationToken)
    {
        var config = new CsvConfiguration(new System.Globalization.CultureInfo("en-US")) { Delimiter = "," };

        #region AnimeScores
        _context.RemoveRange(_context.AnimeScores.Select(a => a));
        using (var reader = new StreamReader("RawData\\animelist.csv", Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            IEnumerable<animelist> records = csv.GetRecords<animelist>();

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
        using (var reader = new StreamReader("RawData\\anime.csv", Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<AnimeMap>();
            IEnumerable<animeraw> records = csv.GetRecords<animeraw>();
            _context.AddRange(records.Adapt<IEnumerable<Anime>>());

        }
        await _context.SaveChangesAsync(cancellationToken);
        #endregion


        return true;



    }

}