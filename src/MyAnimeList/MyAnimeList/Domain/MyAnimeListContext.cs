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

    public DbSet<AnimeGenres> AnimeGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<AnimeProducer> AnimeProducers { get; set; }

    public DbSet<Studio> Studios { get; set; }
    public DbSet<AnimeStudio> AnimesStudios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WatchStatus>()
            .Property(a => a.Id)
            .ValueGeneratedNever();

        modelBuilder.Entity<Anime>()
            .HasKey(p => p.MyAnimeListId);

        modelBuilder.Entity<Anime>()
            .Property(a => a.MyAnimeListId)
            .ValueGeneratedNever();

        modelBuilder.Entity<Genre>()
            .HasKey(a => a.Name);

        modelBuilder.Entity<Studio>()
            .HasKey(p => p.StudioName);

        modelBuilder.Entity<Producer>()
            .HasKey(p => p.Name);

        modelBuilder.Entity<AnimeStudio>()
            .HasOne(p => p.Studio)
            .WithMany(b => b.AnimeStudios)
            .HasForeignKey(b => b.StudioId);

        modelBuilder.Entity<AnimeStudio>()
            .HasOne(p => p.Anime)
            .WithMany(b => b.AnimeStudios)
            .HasPrincipalKey(p => p.MyAnimeListId);

        modelBuilder.Entity<Anime>()
            .HasMany(d => d.AnimeScores)
            .WithOne(d => d.Anime)
            .HasForeignKey(d => d.MyAnimeListId)
            .HasPrincipalKey(d => d.MyAnimeListId);
    }
}