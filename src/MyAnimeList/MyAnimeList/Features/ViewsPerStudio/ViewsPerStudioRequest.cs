using MediatR;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.ViewsPerStudio
{
    public class ViewsPerStudioRequest : IRequest<ResultOf<List<ViewsPerStudioDTO>>>
    {
    }
}
