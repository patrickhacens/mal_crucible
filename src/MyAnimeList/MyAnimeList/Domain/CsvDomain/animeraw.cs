using CsvHelper.Configuration;

namespace MyAnimeList.Domain.CsvDomain;

public class animeraw
{
    public int MAL_ID { get; set; }
    public string Name { get; set; }
    public string Score { get; set; }  
    public string Genres { get; set; }  
    public string English_name { get; set; }
    public string Japanese_name { get; set; }
    public string Type { get; set; }
    public string Episodes { get; set; }
    public string Aired { get; set; }
    public string Premiered { get; set; }
    public string Producers { get; set; }
    public string Licensors { get; set; }
    public string Studios { get; set; }
    public string Source { get; set; }
    public string Duration { get; set; }
    public string Rating { get; set; }
    public string Ranked { get; set; }
    public string Popularity { get; set; }
    public string Members { get; set; }
    public string Favorites { get; set; }
    public string Watching { get; set; }
    public string Completed { get; set; }
    public string On_Hold { get; set; }
    public string Dropped { get; set; }
    public string Plan_to_Watch { get; set; }
    public string Score_10 { get; set; }
    public string Score_9 { get; set; }
    public string Score_8 { get; set; }
    public string Score_7 { get; set; }
    public string Score_6 { get; set; }
    public string Score_5 { get; set; }
    public string Score_4 { get; set; }
    public string Score_3 { get; set; }
    public string Score_2 { get; set; }
    public string Score_1 { get; set; }
}

public sealed class AnimeMap : ClassMap<animeraw>
{
    public AnimeMap()
    {
        Map(m => m.MAL_ID).Name("MAL_ID");
        Map(m => m.Name).Name("Name");
        Map(m => m.Score).Name("Score");
        Map(m => m.Genres).Name("Genres");
        Map(m => m.English_name).Name("English name");
        Map(m => m.Japanese_name).Name("Japanese name");
        Map(m => m.Type).Name("Type");
        Map(m => m.Episodes).Name("Episodes");
        Map(m => m.Aired).Name("Aired");
        Map(m => m.Premiered).Name("Premiered");
        Map(m => m.Producers).Name("Producers");
        Map(m => m.Licensors).Name("Licensors");
        Map(m => m.Studios).Name("Studios");
        Map(m => m.Source).Name("Source");
        Map(m => m.Duration).Name("Duration");
        Map(m => m.Rating).Name("Rating");
        Map(m => m.Ranked).Name("Ranked");
        Map(m => m.Popularity).Name("Popularity");
        Map(m => m.Members).Name("Members");
        Map(m => m.Favorites).Name("Favorites");
        Map(m => m.Watching).Name("Watching");
        Map(m => m.Completed).Name("Completed");
        Map(m => m.On_Hold).Name("On-Hold");
        Map(m => m.Dropped).Name("Dropped");
        Map(m => m.Plan_to_Watch).Name("Plan to Watch");
        Map(m => m.Score_10).Name("Score-10");
        Map(m => m.Score_9).Name("Score-9");
        Map(m => m.Score_8).Name("Score-8");
        Map(m => m.Score_7).Name("Score-7");
        Map(m => m.Score_6).Name("Score-6");
        Map(m => m.Score_5).Name("Score-5");
        Map(m => m.Score_4).Name("Score-4");
        Map(m => m.Score_3).Name("Score-3");
        Map(m => m.Score_2).Name("Score-2");
        Map(m => m.Score_1).Name("Score-1");


    }
}
