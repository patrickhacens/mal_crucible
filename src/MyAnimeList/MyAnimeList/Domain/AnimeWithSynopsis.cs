namespace MyAnimeList.Domain;

public class AnimeWithSynopsis
{
    public int Id { get; set; }
    public int MyAnimeListId { get; set; }
    public string Name { get; set; }
    public decimal? Score { get; set; }  
    public string Genres { get; set; }  
    public string Synopsis { get; set; }
}
