namespace MyAnimeList.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<AnimeGenres> AnimeGenres { get; set;}

    }
}
