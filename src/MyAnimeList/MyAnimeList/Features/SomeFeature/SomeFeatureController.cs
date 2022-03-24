using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Features.SomeFeature.GetSomeFeature;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.SomeFeature
{
    [ApiController]
    [Route("[controller]")]
    public class SomeFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SomeFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public Task<ResultOf<SomeDTO>> GetSomeRequest ([FromRoute]GetSomeFeatureRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }    
}
