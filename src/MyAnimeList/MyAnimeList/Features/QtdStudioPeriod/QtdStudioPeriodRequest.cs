using MediatR;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodRequest : PageRequest, IRequest<ResultOf<PageResult<AnimePerStudioPeriod>>>
{ 
    public int? Ano { get; set; }
    public int? Mes { get; set; }
}
