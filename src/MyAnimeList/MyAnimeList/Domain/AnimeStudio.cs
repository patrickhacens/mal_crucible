namespace MyAnimeList.Domain;

public class AnimeStudio
{
    public int Id { get; set; }
    public int AnimeId { get; set; }
    public string StudioId { get; set; }
    
    public Studio Studio { get; set; }
    public Anime Anime { get; set; }

}
