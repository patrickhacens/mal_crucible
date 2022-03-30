using MediatR;
using Nudes.Retornator.Core;
using Nudes.Paginator.Core;
using MyAnimeList.DTO;
using MyAnimeList.Domain;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodHandler : IRequestHandler<QtdStudioPeriodRequest, ResultOf<PageResult<AnimePerStudioPeriod>>>
{
    private readonly MyAnimeListContext _context;
    public QtdStudioPeriodHandler(MyAnimeListContext context)
    {
        _context = context;
    }

    public Task<ResultOf<PageResult<AnimePerStudioPeriod>>> Handle(QtdStudioPeriodRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


