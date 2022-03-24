using FluentValidation;

namespace MyAnimeList.Features.SomeFeature.GetSomeFeature
{
    public class GetSomeFeatureRequestValidator : AbstractValidator<GetSomeFeatureRequest>
    {
        public GetSomeFeatureRequestValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);
        }
    }
}
