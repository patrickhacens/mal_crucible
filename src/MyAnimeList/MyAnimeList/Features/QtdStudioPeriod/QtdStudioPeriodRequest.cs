using MediatR;
using MyAnimeList.DTO;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodRequest : PageRequest, IRequest<ResultOf<PageResult<AnimePerStudioPeriod>>>
{
<<<<<<< HEAD
    public int ano { get; set; }
    public int mes { get; set; }
=======
    public int ano;
    public int mes;
>>>>>>> b8e770cf411d41109d687957dbe1cb09d8f8e8f9
}
