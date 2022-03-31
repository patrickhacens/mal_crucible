using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MyAnimeList.Features.AnimesPerGenre;
using MyAnimeList.Domain;
using MyAnimeList.DTO;
using MyAnimeList.Features.Import;
using MyAnimeList.Models;
using MyAnimeList.Features.RankingAnime;


using MyAnimeList.Features.QtdStudioPeriod;
<<<<<<< HEAD
>>>>>>> Request, Handler and Validator prepared
=======

>>>>>>> Fiels StartDate and EndDate inserted on table Animes
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
        public Task<Result>Import(ImportDataRequest request,CancellationToken cancellation)
            => _mediator.Send(request,cancellation);

        [HttpGet("/animes/genre")]
        public Task<ResultOf<List<AnimesPerGenresDTO>>> AnimesPerGenres([FromQuery]AnimesPerGenresRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }           


        [HttpGet]
        [Route("/animes/studio/releases")]
        public Task<ResultOf<PageResult<AnimePerStudioPeriod>>> AnimeStudioRelease([FromQuery] QtdStudioPeriodRequest request, CancellationToken cancellation)
            => _mediator.Send(request,cancellation);

<<<<<<< HEAD
>>>>>>> Request, Handler and Validator prepared
            
>>>>>>> Rebase da Issue5
=======

>>>>>>> Fiels StartDate and EndDate inserted on table Animes
    }
}
