﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.DTO;
using MyAnimeList.Features.Import;
using MyAnimeList.Features.QtdStudioPeriod;
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
        public Task<ResultOf<bool>>Seed(ImportDataRequest request,CancellationToken cancellation)
            => _mediator.Send(request,cancellation);


        [HttpGet]
        [Route("/animes/studio/releases")]
        public Task<ResultOf<PageResult<AnimePerStudioPeriod>>> AnimeStudioRelease([FromQuery] QtdStudioPeriodRequest request, CancellationToken cancellation)
            => _mediator.Send(request,cancellation);

            
    }
}
