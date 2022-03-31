using MediatR;
using MyAnimeList.DTO;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodRequest : PageRequest, IRequest<ResultOf<PageResult<AnimePerStudioPeriod>>>
<<<<<<< HEAD
{
    public int ano;
    public int mes;
=======
{ 
    public int ano { get; set; }
    public int mes { get; set; }
>>>>>>> Fiels StartDate and EndDate inserted on table Animes
}
