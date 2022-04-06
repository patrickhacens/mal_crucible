using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.EngagingPerStudio
{
    public class EngagingPerStudioHandler : IRequestHandler<EngagingPerStudioRequest, ResultOf<PageResult<EngagingPerStudioDTO>>>
    {
        private readonly MyAnimeListContext context;

        public EngagingPerStudioHandler(MyAnimeListContext context)
        {
            this.context = context;
        }
        public async Task<ResultOf<PageResult<EngagingPerStudioDTO>>> Handle(EngagingPerStudioRequest request, CancellationToken cancellationToken)
        {
            var query = context.AnimesStudios
                .Include(a => a.Anime)
                .Include(a => a.Studio)
                .Select(a => new
                {
                    a.AnimeId,
                    a.StudioId,
                    AnimeEngaging = (a.Anime.Watching.Value + a.Anime.Completed.Value + a.Anime.OnHold + a.Anime.Dropped) == 0
                            ? 0
                            : a.Anime.Completed.Value / (double)(a.Anime.Watching.Value + a.Anime.Completed.Value + a.Anime.OnHold + a.Anime.Dropped)
                }).GroupBy(a => a.StudioId)
                .Select(a => new EngagingPerStudioDTO()
                {
                    StudioName = a.Key,
                    Engaging = a.Average(x => x.AnimeEngaging)
                });

            var total = await query.CountAsync(cancellationToken);

            var list = await query.PaginateBy(request, a => a.StudioName).ToListAsync(cancellationToken);

            return new PageResult<EngagingPerStudioDTO>(request, total, list);
        }
    }
}
