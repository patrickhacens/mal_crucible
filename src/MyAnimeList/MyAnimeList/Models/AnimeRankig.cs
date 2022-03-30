using MyAnimeList.Domain;

namespace MyAnimeList.DTO;

public class AnimeRanking
{
    public int MyAnimeListId { get; set; }
    public double EstrelaIndex { get; set; }
    public Anime Anime { get; set; }
}
