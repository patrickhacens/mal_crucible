using MediatR;
using MyAnimeList.DTO;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodRequest : PageRequest, IRequest<ResultOf<PageResult<AnimePerStudioPeriod>>>
{ 
    public int ano { get; set; }
    public int mes { get; set; }
}
