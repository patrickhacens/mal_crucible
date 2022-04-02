namespace MyAnimeList.Domain
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<AnimeProducer> Producers { get; set; }
    }
}
