using MediatR;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.EngagingPerStudio
{
    public class EngagingPerStudioRequest : PageRequest, IRequest<ResultOf<PageResult<EngagingPerStudioDTO>>>
    {
    }
}
