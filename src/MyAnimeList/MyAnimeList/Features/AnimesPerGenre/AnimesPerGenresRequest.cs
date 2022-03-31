using MediatR;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.AnimesPerGenre
{
    public class AnimesPerGenresRequest :IRequest<ResultOf<List<AnimesPerGenresDTO>>>
    {
    }
}
