namespace MyAnimeList.Domain
{
    public class AnimeGenres
    {
        public int Id { get; set; }
        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}
