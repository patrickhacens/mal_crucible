using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Features.AnimesPerGenre;
using MyAnimeList.Domain;
using MyAnimeList.DTO;
using MyAnimeList.Features.Import;
using MyAnimeList.Models;
using MyAnimeList.Features.RankingAnime;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using MyAnimeList.Features.EngagingPerAnime;
using MyAnimeList.Features.ViewsPerGenre;
using MyAnimeList.Features.ViewsPerProducer;

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
        public Task<Result>Import(ImportDataRequest request,CancellationToken cancellation)
            => _mediator.Send(request,cancellation);

        [HttpGet("/animes/genre")]
        public Task<ResultOf<List<AnimesPerGenresDTO>>> AnimesPerGenres([FromQuery]AnimesPerGenresRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpGet("/animes/genre/views")]
        public Task<ResultOf<List<ViewPerGenreDTO>>> ViewsPerGenres([FromQuery] ViewsPerGenreRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpGet("/animes/engaging")]
        public Task<ResultOf<PageResult<EngagingPerAnimeDTO>>> EngagingPerAnime([FromQuery] EngagingPerAnimeRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpGet("/animes/producer/views")]
        public Task<ResultOf<List<ViewsPerProducerDTO>>> ViewsPErPRoducer([FromQuery] ViewsPerProducerRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
