using CsvHelper.Configuration;

namespace MyAnimeList.Domain.CsvDomain;

public class AnimeWithSynopsisCsv
{
    public int MyAnimeListId { get; set; }
    public string Name { get; set; }
    public decimal? Score { get; set; }
    public string Genres { get; set; }
    public string Synopsis { get; set; }
}

public sealed class AnimeWithSynopsisMap : ClassMap<AnimeWithSynopsisCsv>
{
    public AnimeWithSynopsisMap()
    {
        Map(m => m.MyAnimeListId).Name("MAL_ID");
        Map(m => m.Name).Name("Name").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Score).Name("Score").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Genres).Name("Genres").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Synopsis).Name("sypnopsis").TypeConverter<UnknownStringConverter<string>>();
    }
}