namespace MyAnimeList.Domain
{
    public class AnimeProducer
    {
        public int Id { get; set; }

        public int AnimeId { get; set; }
        public virtual Anime Anime { get; set; }

        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
