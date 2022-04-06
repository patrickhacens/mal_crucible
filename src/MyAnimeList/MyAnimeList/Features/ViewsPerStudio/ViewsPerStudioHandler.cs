using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.ViewsPerStudio
{
    public class ViewsPerStudioHandler : IRequestHandler<ViewsPerStudioRequest, ResultOf<List<ViewsPerStudioDTO>>>
    {
        private readonly MyAnimeListContext context;

        public ViewsPerStudioHandler(MyAnimeListContext context)
        {
            this.context = context;
        }
        public async Task<ResultOf<List<ViewsPerStudioDTO>>> Handle(ViewsPerStudioRequest request, CancellationToken cancellationToken)
        {
            return await context.Animes.Join(context.AnimeScores, a => a.MyAnimeListId, b => b.MyAnimeListId, (a, b) => new
            {
                MyAnimeListId = a.MyAnimeListId,
                WatchedEpisodes = b.WatchedEpisodes,
            }).GroupBy(a => new { a.MyAnimeListId })
            .Select(a => new
            {
                MyAnimeListId = a.Key.MyAnimeListId,
                Soma = a.Sum(a => a.WatchedEpisodes),
            }).Join(context.AnimesStudios, a => a.MyAnimeListId, b => b.AnimeId, (a, b) => new
            {
                Studio = context.Studios.Where(c => c.StudioName == b.StudioId).Select(d => d.StudioName).First(),
                Soma = a.Soma
            }).GroupBy(d => d.Studio)
            .Select(a => new ViewsPerStudioDTO()
            {
                StudioName = a.Key,
                Views = a.Sum(a => a.Soma)
            }).OrderBy(a => a.StudioName).ToListAsync(cancellationToken);
        }
    }
}
