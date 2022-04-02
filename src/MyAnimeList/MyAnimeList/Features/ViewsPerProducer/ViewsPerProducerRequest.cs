using MediatR;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.ViewsPerProducer
{
    public class ViewsPerProducerRequest : IRequest<ResultOf<List<ViewsPerProducerDTO>>>
    {
    }
}
