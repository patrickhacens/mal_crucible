using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Domain;
using MyAnimeList.DTO;
using MyAnimeList.Features.Import;
using MyAnimeList.Features.RankingAnime;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList
{
    [Route("/")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("import")]
        public Task<ResultOf<bool>>Import(ImportDataRequest request,CancellationToken cancellation)
            => _mediator.Send(request,cancellation);

        [HttpGet]
        [Route("ranking")]
        public Task<ResultOf<PageResult<AnimeRanking>>> Ranking([FromQuery] RankingAnimeRequest request,CancellationToken cancellation)
            => _mediator.Send(request,cancellation);
            
    }
}
