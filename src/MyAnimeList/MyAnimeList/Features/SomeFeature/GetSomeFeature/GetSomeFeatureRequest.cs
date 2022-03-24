using MediatR;
using MyAnimeList.Models;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.SomeFeature.GetSomeFeature
{
    public class GetSomeFeatureRequest : IRequest<ResultOf<SomeDTO>>
    {
        public int Id { get; set; }
    }
}
