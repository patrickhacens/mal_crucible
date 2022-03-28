using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Features.Ranking.GeometricRank;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.Ranking
{
    [ApiController]
    [Route("[controller]")]

    public class RankingController : ControllerBase
    {
        private readonly IMediator mediator;

        public RankingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/rank/geometric")]
        public Task<ResultOf<PageResult<AnimeRankDTO>>> GeometricRank([FromQuery]AnimeGeometricRankRequest animeGeometricRankRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(animeGeometricRankRequest, cancellationToken);
        }
    }
}
