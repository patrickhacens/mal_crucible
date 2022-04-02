using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.EngagingPerAnime
{
    public class EngagingPerAnimeHandler : IRequestHandler<EngagingPerAnimeRequest, ResultOf<PageResult<EngagingPerAnimeDTO>>>
    {
        private readonly MyAnimeListContext context;

        public EngagingPerAnimeHandler(MyAnimeListContext context)
        {
            this.context = context;
        }
        public async Task<ResultOf<PageResult<EngagingPerAnimeDTO>>> Handle(EngagingPerAnimeRequest request, CancellationToken cancellationToken)
        {
            var query = context.Animes.Select(a => new EngagingPerAnimeDTO()
            {
                AnimeName = a.Name,
                Engaging = (a.Watching.Value + a.Completed.Value + a.OnHold + a.Dropped) == 0 
                    ? 0
                    : a.Completed.Value / (double)(a.Watching + a.Completed + a.OnHold + a.Dropped)
            });

            var total = await query.CountAsync(cancellationToken);

            var engagingList = await query.PaginateByDescending(request, a => a.Engaging).ToListAsync(cancellationToken);

            return new PageResult<EngagingPerAnimeDTO>(request, total, engagingList);
        }
    }
}
