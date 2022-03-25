namespace MyAnimeList.Domain;
public class RatingFromComplete
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MyAnimeListId { get; set; }
    public decimal Rating { get; set; } 

}
