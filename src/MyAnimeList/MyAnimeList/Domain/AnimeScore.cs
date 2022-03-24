namespace MyAnimeList.Domain;

public class AnimeScore
{
    public int Id { get; set; }
    public int userid { get; set; }
    public int animeid { get; set; }
    public decimal score { get; set; }
    public int watching_status { get; set; }
    public int watched_episodes { get; set; }

}
