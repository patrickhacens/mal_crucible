using Mapster;
using MyAnimeList.Features.SomeFeature.GetSomeFeature;
using MyAnimeList.Models;

namespace MyAnimeList.Adapters
{
    public class SomeAdapter : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetSomeFeatureRequest, SomeDTO>()
                .Map(dto => dto.ReturnId, request => request.Id);
        }
    }
}
