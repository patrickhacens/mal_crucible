using MediatR;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.ViewsPerGenre
{
    public class ViewsPerGenreRequest : IRequest<ResultOf<List<ViewPerGenreDTO>>>
    {
    }
}
