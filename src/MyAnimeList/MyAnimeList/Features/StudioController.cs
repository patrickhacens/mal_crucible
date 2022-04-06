using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Features.EngagingPerStudio;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features
{

    [Route("/")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/studio/engaging")]
        public Task<ResultOf<PageResult<EngagingPerStudioDTO>>> ViewsPerGenres([FromQuery] EngagingPerStudioRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
