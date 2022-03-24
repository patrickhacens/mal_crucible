using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyAnimeList.Domain.CsvDomain;
using System.Text;

namespace MyAnimeList.Domain;

public class MyAnimeListContext : DbContext
{
    public MyAnimeListContext(DbContextOptions<MyAnimeListContext> options) : base(options)
    {
    }
    
    public DbSet<Anime> Animes { get; set; }    
    public DbSet<AnimeScore> AnimeScores { get; set; }
    public DbSet<AnimeWithSynopsis> AnimesWithSynopsis { get; set; }
    public DbSet<RatingFromComplete> RatingCompletes { get; set; }  
    public DbSet<WatchStatus> WatchStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var config = new CsvConfiguration(new System.Globalization.CultureInfo("en-US")) { Delimiter = "," };

        using (var reader = new StreamReader("RawData\\animelist.csv", Encoding.UTF8))
        using (var csv = new CsvReader(reader, config))
        {
            IEnumerable<animelist> records = csv.GetRecords<animelist>();
            int counter = 1;
            modelBuilder.Entity<AnimeScore>().HasData(records.Select(a => new AnimeScore {
                Id = counter++,
                animeid = a.anime_id,
                score = a.rating,
                watching_status = a.watching_status,
                watched_episodes = a.watched_episodes,
                userid = a.user_id
            }));
        }
        
    }
   
}
