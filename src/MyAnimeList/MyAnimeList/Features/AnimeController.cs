﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
<<<<<<< HEAD
using MyAnimeList.Features.AnimesPerGenre;
using MyAnimeList.Domain;
using MyAnimeList.DTO;
using MyAnimeList.Features.Import;
using MyAnimeList.Models;
using MyAnimeList.Features.RankingAnime;
=======
using MyAnimeList.Features.Import;
>>>>>>> Rebase da Issue5
=======
using MyAnimeList.DTO;
using MyAnimeList.Features.Import;
using MyAnimeList.Features.QtdStudioPeriod;
>>>>>>> Request, Handler and Validator prepared
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
<<<<<<< HEAD
<<<<<<< HEAD

        [HttpGet("/animes/genre")]
        public Task<ResultOf<List<AnimesPerGenresDTO>>> AnimesPerGenres([FromQuery]AnimesPerGenresRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }           
=======
=======


        [HttpGet]
        [Route("/animes/studio/releases")]
        public Task<ResultOf<PageResult<AnimePerStudioPeriod>>> AnimeStudioRelease([FromQuery] QtdStudioPeriodRequest request, CancellationToken cancellation)
            => _mediator.Send(request,cancellation);

>>>>>>> Request, Handler and Validator prepared
            
>>>>>>> Rebase da Issue5
    }
}
