using MediatR;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.Ranking.GeometricRank
{
    public class AnimeGeometricRankRequest : PageRequest, IRequest<ResultOf<PageResult<AnimeRankDTO>>>
    {
    }
}
