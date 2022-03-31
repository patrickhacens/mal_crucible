using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.AnimesPerGenre
{
    public class AnimesPerGenresHandler : IRequestHandler<AnimesPerGenresRequest, ResultOf<List<AnimesPerGenresDTO>>>
    {
        private readonly MyAnimeListContext context;

        public AnimesPerGenresHandler(MyAnimeListContext context)
        {
            this.context = context;
        }
        public async Task<ResultOf<List<AnimesPerGenresDTO>>> Handle(AnimesPerGenresRequest request, CancellationToken cancellationToken)
        {
            return await context.AnimeGenres.Include(d => d.Genre).GroupBy(d => d.GenreId).Select(d => new AnimesPerGenresDTO()
            {
                Genre = d.First().Genre.Name,
                Quantity = d.Count()
            }).ToListAsync(cancellationToken);
        }
    }
}
