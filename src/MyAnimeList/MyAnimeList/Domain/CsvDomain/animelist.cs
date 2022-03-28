namespace MyAnimeList.Domain.CsvDomain;

public class AnimeList
{
    public int user_id { get; set; }
    public int anime_id { get; set; }   
    public int rating { get; set; } 
    public int watching_status { get; set; }
    public int watched_episodes { get; set; }
}
