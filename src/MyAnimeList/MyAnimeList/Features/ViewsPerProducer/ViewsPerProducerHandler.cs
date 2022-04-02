using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.ViewsPerProducer
{
    public class ViewsPerProducerHandler : IRequestHandler<ViewsPerProducerRequest, ResultOf<List<ViewsPerProducerDTO>>>
    {
        private readonly MyAnimeListContext context;

        public ViewsPerProducerHandler(MyAnimeListContext context)
        {
            this.context = context;
        }
        public async Task<ResultOf<List<ViewsPerProducerDTO>>> Handle(ViewsPerProducerRequest request, CancellationToken cancellationToken)
        {
            return await context.Animes.Join(context.AnimeScores, a => a.MyAnimeListId, b => b.MyAnimeListId, (a, b) => new
            {
                MyAnimeListId = a.MyAnimeListId,
                WatchedEpisodes = b.WatchedEpisodes,
                Id = a.Id,
            }).GroupBy(a => new { a.MyAnimeListId })
            .Select(a => new
            {
                MyAnimeListId = a.Key.MyAnimeListId,
                Soma = a.Sum(a => a.WatchedEpisodes),
                Id = a.Min(a => a.Id)
            }).Join(context.AnimeProducers, a => a.Id, b => b.AnimeId, (a, b) => new
            {
                Producer = context.Producers.Where(c => c.Id == b.ProducerId).Select(d => d.Name).First(),
                Soma = a.Soma
            }).GroupBy(d => d.Producer)
            .Select(a => new ViewsPerProducerDTO()
            {
                ProducerName = a.Key,
                Views = a.Sum(a => a.Soma)
            }).OrderBy(a => a.ProducerName).ToListAsync(cancellationToken);
        }
    }
}
