using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.AnimePerStudioPerPeriod
{
    public class AnimesPerStudioPerPeriodRequest : PageRequest, IRequest<ResultOf<AnimesPerStudioPerPeriodDTO>>
    {
        [FromRoute]
        public string StudioName { get; set; }
    }
}
