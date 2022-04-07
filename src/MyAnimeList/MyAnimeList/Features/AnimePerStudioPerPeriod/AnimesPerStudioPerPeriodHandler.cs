using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Models;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.AnimePerStudioPerPeriod
{
    public class AnimesPerStudioPerPeriodHandler : IRequestHandler<AnimesPerStudioPerPeriodRequest, ResultOf<AnimesPerStudioPerPeriodDTO>>
    {
        private readonly MyAnimeListContext context;

        public AnimesPerStudioPerPeriodHandler(MyAnimeListContext context)
        {
            this.context = context;
        }
        public async Task<ResultOf<AnimesPerStudioPerPeriodDTO>> Handle(AnimesPerStudioPerPeriodRequest request, CancellationToken cancellationToken)
        {
            var query = context.AnimesStudios.AsQueryable()
                .Include(a => a.Anime)
                .Where(a => a.StudioId == request.StudioName)
                .GroupBy(a => a.Anime.Premiered)
                .Select(a => new QuantityAiredPerPeriod()
                {
                    Period = a.Key,
                    Quantity = a.Count()
                });

            var totalPeriods = await query.CountAsync(cancellationToken);

            var list = await query.PaginateBy(request, a => a.Period).ToListAsync(cancellationToken);

            return new AnimesPerStudioPerPeriodDTO()
            {
                StudioName = request.StudioName,
                Total = list.Sum(a => a.Quantity),
                QuantityAiredPerPeriods = new PageResult<QuantityAiredPerPeriod>(request, totalPeriods, list)
            };
        }
    }
}
