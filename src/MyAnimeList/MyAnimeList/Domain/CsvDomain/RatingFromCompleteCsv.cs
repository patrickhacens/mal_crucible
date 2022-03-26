using CsvHelper.Configuration;

namespace MyAnimeList.Domain.CsvDomain;

public class RatingFromCompleteCsv
{
    public int UserId { get; set; }
    public int MyAnimeListId { get; set; }
    public decimal? Rating { get; set; }
}

public sealed class RatingFromCompleteMap : ClassMap<RatingFromCompleteCsv>
{
    public RatingFromCompleteMap()
    {
        Map(m => m.UserId).Name("user_id");
        Map(m => m.MyAnimeListId).Name("anime_id");
        Map(m => m.Rating).Name("rating").TypeConverter<UnknownDecimalConverter<string>>();
    }
}


