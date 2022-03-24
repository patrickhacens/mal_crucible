using Mapster;
using MediatR;
using MyAnimeList.Models;
using Nudes.Retornator.Core;
using System.Timers;

namespace MyAnimeList.Features.SomeFeature.GetSomeFeature
{
    public class GetSomeFeatureHandler : IRequestHandler<GetSomeFeatureRequest, ResultOf<SomeDTO>>
    {
        public async Task<ResultOf<SomeDTO>> Handle(GetSomeFeatureRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            return request.Adapt<SomeDTO>();
        }
    }
}
