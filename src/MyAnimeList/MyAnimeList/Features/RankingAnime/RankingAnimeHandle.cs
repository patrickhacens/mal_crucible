using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.DTO;
using Nudes.Paginator.Core;

using Nudes.Retornator.Core;


namespace MyAnimeList.Features.RankingAnime;

public class RankingAnimeHandle : IRequestHandler<RankingAnimeRequest, ResultOf<PageResult<AnimeRanking>>>
{
    private readonly MyAnimeListContext _context;

    public RankingAnimeHandle(MyAnimeListContext context)
    {
        _context = context;
    }
    public async Task<ResultOf<PageResult<AnimeRanking>>> Handle(RankingAnimeRequest query, CancellationToken cancellationToken)
    {
        var records = _context.AnimeScores.GroupBy(x => new { x.Score, x.MyAnimeListId }).Select(x => new
        {
            MyAnimeListId = x.Key.MyAnimeListId,
            Score = x.Key.Score,
            TotalScore = x.Count()
        }).GroupBy(x => x.MyAnimeListId).Select(x => new AnimeRanking
        {
            MyAnimeListId = x.Key,
            EstrelaIndex = x.Sum(x => Math.Pow((double)(x.Score - 5), 3.0) * x.TotalScore) / 325,
            Anime = _context.Animes.Where(y => y.MyAnimeListId == x.Key).FirstOrDefault()
        });


        var total = _context.AnimeScores.Count();
        var itens = await records.PaginateByDescending(query, d => d.EstrelaIndex).ToListAsync(cancellationToken);

        

        return new PageResult<AnimeRanking>(query, total, itens);
    }
}
