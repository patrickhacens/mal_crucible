using Nudes.Paginator.Core;

namespace MyAnimeList.Models
{
    public class AnimesPerStudioPerPeriodDTO
    {
        public string StudioName { get; set; }
        public int Total { get; set; }
        public PageResult<QuantityAiredPerPeriod> QuantityAiredPerPeriods { get; set; }
    }
}
