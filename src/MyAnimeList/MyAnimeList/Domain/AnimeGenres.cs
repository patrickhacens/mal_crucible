namespace MyAnimeList.Domain
{
    public class AnimeGenres
    {
        public int Id { get; set; }
        
        public string GenreName { get; set; }
        public virtual Genre Genre { get; set; }

        public int AnimeId { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
