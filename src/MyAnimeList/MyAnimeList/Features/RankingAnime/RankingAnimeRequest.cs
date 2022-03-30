using MediatR;
using MyAnimeList.Domain;
using MyAnimeList.DTO;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.RankingAnime;

public class RankingAnimeRequest : PageRequest, IRequest<ResultOf<PageResult<AnimeRanking>>>
{
    
}

