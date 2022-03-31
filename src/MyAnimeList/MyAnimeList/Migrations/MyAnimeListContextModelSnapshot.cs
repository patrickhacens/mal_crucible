﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAnimeList.Domain;

#nullable disable

namespace MyAnimeList.Migrations
{
    [DbContext(typeof(MyAnimeListContext))]
    partial class MyAnimeListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyAnimeList.Domain.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Completed")
                        .HasColumnType("int");

                    b.Property<int?>("Dropped")
                        .HasColumnType("int");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Episodes")
                        .HasColumnType("int");

                    b.Property<int?>("Favorites")
                        .HasColumnType("int");

                    b.Property<string>("JapaneseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Licensors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Members")
                        .HasColumnType("int");

                    b.Property<int>("MyAnimeListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OnHold")
                        .HasColumnType("int");

                    b.Property<int?>("PlanToWatch")
                        .HasColumnType("int");

                    b.Property<int?>("Popularity")
                        .HasColumnType("int");

                    b.Property<string>("Premiered")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Ranked")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double?>("Score01")
                        .HasColumnType("float");

                    b.Property<double?>("Score02")
                        .HasColumnType("float");

                    b.Property<double?>("Score03")
                        .HasColumnType("float");

                    b.Property<double?>("Score04")
                        .HasColumnType("float");

                    b.Property<double?>("Score05")
                        .HasColumnType("float");

                    b.Property<double?>("Score06")
                        .HasColumnType("float");

                    b.Property<double?>("Score07")
                        .HasColumnType("float");

                    b.Property<double?>("Score08")
                        .HasColumnType("float");

                    b.Property<double?>("Score09")
                        .HasColumnType("float");

                    b.Property<double?>("Score10")
                        .HasColumnType("float");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Watching")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("MyAnimeList.Domain.AnimeGenres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("GenreId");

                    b.ToTable("AnimeGenres");
                });

            modelBuilder.Entity("MyAnimeList.Domain.AnimeScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MyAnimeListId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WatchedEpisodes")
                        .HasColumnType("int");

                    b.Property<int>("WatchingStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AnimeScores");
                });

            modelBuilder.Entity("MyAnimeList.Domain.AnimeWithSynopsis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyAnimeListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimesWithSynopsis");
                });

            modelBuilder.Entity("MyAnimeList.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MyAnimeList.Domain.RatingFromComplete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MyAnimeListId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RatingCompletes");
                });

            modelBuilder.Entity("MyAnimeList.Domain.WatchStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WatchStatus");
                });

            modelBuilder.Entity("MyAnimeList.Domain.AnimeGenres", b =>
                {
                    b.HasOne("MyAnimeList.Domain.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAnimeList.Domain.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
