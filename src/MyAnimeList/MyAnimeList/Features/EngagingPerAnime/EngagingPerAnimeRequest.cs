using MediatR;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.EngagingPerAnime
{
    public class EngagingPerAnimeRequest : PageRequest, IRequest<ResultOf<PageResult<EngagingPerAnimeDTO>>>
    {
    }
}
