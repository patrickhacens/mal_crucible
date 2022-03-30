using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.DTO;
using MyAnimeList.Features.RankingAnime;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features;

[Route("api/[controller]")]
[ApiController]
public class RankingController : ControllerBase
{
    private readonly IMediator _mediator;
    public RankingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("/rank/index")]
    public Task<ResultOf<PageResult<AnimeRanking>>> Ranking([FromQuery] RankingAnimeRequest request, CancellationToken cancellation)
    => _mediator.Send(request, cancellation);
}
