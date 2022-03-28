﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAnimeList.Domain;

#nullable disable

namespace MyAnimeList.Migrations
{
    [DbContext(typeof(MyAnimeListContext))]
    [Migration("20220326201907_Filed Name Added to Table AnimeWithSynopsis")]
    partial class FiledNameAddedtoTableAnimeWithSynopsis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<decimal?>("Score01")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score02")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score03")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score04")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score05")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score06")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score07")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score08")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score09")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Score10")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimesWithSynopsis");
                });

            modelBuilder.Entity("MyAnimeList.Domain.RatingFromComplete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MyAnimeListId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RatingCompletes");
                });

            modelBuilder.Entity("MyAnimeList.Domain.WatchStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WatchStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
