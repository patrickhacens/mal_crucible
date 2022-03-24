namespace MyAnimeList.Domain;

public class AnimeWithSynopsis
{
    public int Id { get; set; }
    public int MyAnimeListId { get; set; }
    public decimal Score { get; set; }  
    public string genres { get; set; }  
    public string synopsis { get; set; }
}
