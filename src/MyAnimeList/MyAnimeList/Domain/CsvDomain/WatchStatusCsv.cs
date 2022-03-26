using CsvHelper.Configuration;

namespace MyAnimeList.Domain.CsvDomain;

public class WatchStatusCsv
{
    public int Id { get; set; }
    public string Description { get; set; }
}

public class WatchStatusMap : ClassMap<WatchStatusCsv>
{
    public WatchStatusMap()
    {
        Map(m => m.Id).Name("status");
        Map(m => m.Description).Name(" description");
    }
}

