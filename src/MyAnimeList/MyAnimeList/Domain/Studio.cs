namespace MyAnimeList.Domain;

public class Studio
{
    public string StudioName { get; set; }
    public virtual List<AnimeStudio> AnimeStudios { get; set; }
}
