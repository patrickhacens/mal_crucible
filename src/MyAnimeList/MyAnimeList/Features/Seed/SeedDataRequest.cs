using MediatR;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.Seed;

public class SeedDataRequest : IRequest<ResultOf<bool>>
{
}
