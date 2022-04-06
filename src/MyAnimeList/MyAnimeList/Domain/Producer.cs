namespace MyAnimeList.Domain
{
    public class Producer
    {
        public string Name { get; set; }
        public virtual List<AnimeProducer> Producers { get; set; }
    }
}
