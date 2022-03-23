using Microsoft.EntityFrameworkCore;

namespace MyAnimeList.Models;

public class MyAnimeListContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }    
    public DbSet<AnimeScore> AnimeScores { get; set; }
    public DbSet<AnimeWithSynopsis> AnimesWithSynopsis { get; set; }
    public DbSet<RatingFromComplete> RatingFromCompletes { get; set; }  
    public DbSet<WatchStatus> WatchStatuses { get; set; }

}
