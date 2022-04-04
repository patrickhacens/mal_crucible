namespace MyAnimeList.Domain
{
    public class Genre
    {
        public string Name { get; set; }
        public virtual List<AnimeGenres> AnimeGenres { get; set;}

    }
}
