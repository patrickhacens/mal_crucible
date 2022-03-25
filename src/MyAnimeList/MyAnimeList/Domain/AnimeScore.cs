namespace MyAnimeList.Domain;

public class AnimeScore
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MyAnimeListId { get; set; }
    public int Score { get; set; }
    public int WatchingStatus { get; set; }
    public int WatchedEpisodes { get; set; }

}
