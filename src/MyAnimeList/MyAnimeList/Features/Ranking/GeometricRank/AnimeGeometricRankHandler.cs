using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.Ranking.GeometricRank
{
    public class AnimeGeometricRankHandler : IRequestHandler<AnimeGeometricRankRequest, ResultOf<PageResult<AnimeRankDTO>>>
    {
        private readonly MyAnimeListContext _context;

        public AnimeGeometricRankHandler(MyAnimeListContext context)
        {
            _context = context;
        }
        public async Task<ResultOf<PageResult<AnimeRankDTO>>> Handle(AnimeGeometricRankRequest request, CancellationToken cancellationToken)
        {
            var list = _context
                .Animes
                .Select(anime => new AnimeRankDTO()
                {
                    MyAnimeListID = anime.MyAnimeListId,

                    IndexRank = Math.Pow(
                          (1d / (anime.Score01 ?? 1d))
                        * (2d / (anime.Score02 ?? 2d))
                        * (3d / (anime.Score03 ?? 3d))
                        * (4d / (anime.Score04 ?? 4d))
                        * (5d / (anime.Score05 ?? 5d))
                        * (6d / (anime.Score06 ?? 6d))
                        * (7d / (anime.Score07 ?? 7d))
                        * (8d / (anime.Score08 ?? 8d))
                        * (9d / (anime.Score09 ?? 9d))
                        * (10d / (anime.Score10 ?? 10d))
                        , 0.1d),
                });
            
            var total = await list.CountAsync(cancellationToken);

            var animeRank = await list
                .PaginateByDescending(request, p => p.IndexRank)
                .ToListAsync(cancellationToken);

            return new PageResult<AnimeRankDTO>(request, total, animeRank);
        }
    }
}
