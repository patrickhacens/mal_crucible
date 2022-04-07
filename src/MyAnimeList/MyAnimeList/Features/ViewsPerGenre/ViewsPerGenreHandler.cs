using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.ViewsPerGenre
{
    public class ViewsPerGenreHandler : IRequestHandler<ViewsPerGenreRequest, ResultOf<List<ViewPerGenreDTO>>>
    {
        private readonly MyAnimeListContext _context;

        public ViewsPerGenreHandler(MyAnimeListContext context)
        {
            this._context = context;
        }
        public async Task<ResultOf<List<ViewPerGenreDTO>>> Handle(ViewsPerGenreRequest request, CancellationToken cancellationToken)
        {
            return await _context.Animes.Join(_context.AnimeScores, a => a.MyAnimeListId, b => b.MyAnimeListId, (a, b) => new
            {
                MyAnimeListId = a.MyAnimeListId,
                WatchedEpisodes = b.WatchedEpisodes,
            }).GroupBy(a => new { a.MyAnimeListId })
            .Select(a => new
            {
                MyAnimeListId = a.Key.MyAnimeListId,
                Soma = a.Sum(a => a.WatchedEpisodes),
            }).Join(_context.AnimeGenres, a => a.MyAnimeListId, b => b.AnimeId, (a, b) => new
            {
                Genre = _context.Genres.Where(c => c.Name == b.GenreName).Select(d => d.Name).First(),
                Soma = a.Soma
            }).GroupBy(d => d.Genre)
            .Select(a => new ViewPerGenreDTO()
            {
                Genre = a.Key,
                Views = a.Sum(a => a.Soma)
            }).OrderBy(a => a.Genre).ToListAsync(cancellationToken);
        }
    }
}
