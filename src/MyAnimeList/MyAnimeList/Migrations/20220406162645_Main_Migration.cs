using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class Main_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    MyAnimeListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JapaneseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Episodes = table.Column<int>(type: "int", nullable: true),
                    StartDateAired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateAired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premiered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Licensors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Studios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ranked = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: true),
                    Members = table.Column<int>(type: "int", nullable: true),
                    Favorites = table.Column<int>(type: "int", nullable: true),
                    Watching = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    OnHold = table.Column<int>(type: "int", nullable: true),
                    Dropped = table.Column<int>(type: "int", nullable: true),
                    PlanToWatch = table.Column<int>(type: "int", nullable: true),
                    Score10 = table.Column<double>(type: "float", nullable: true),
                    Score09 = table.Column<double>(type: "float", nullable: true),
                    Score08 = table.Column<double>(type: "float", nullable: true),
                    Score07 = table.Column<double>(type: "float", nullable: true),
                    Score06 = table.Column<double>(type: "float", nullable: true),
                    Score05 = table.Column<double>(type: "float", nullable: true),
                    Score04 = table.Column<double>(type: "float", nullable: true),
                    Score03 = table.Column<double>(type: "float", nullable: true),
                    Score02 = table.Column<double>(type: "float", nullable: true),
                    Score01 = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.MyAnimeListId);
                });

            migrationBuilder.CreateTable(
                name: "AnimesWithSynopsis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyAnimeListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesWithSynopsis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RatingCompletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MyAnimeListId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingCompletes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioName);
                });

            migrationBuilder.CreateTable(
                name: "WatchStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MyAnimeListId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    WatchingStatus = table.Column<int>(type: "int", nullable: false),
                    WatchedEpisodes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeScores_Animes_MyAnimeListId",
                        column: x => x.MyAnimeListId,
                        principalTable: "Animes",
                        principalColumn: "MyAnimeListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeGenres_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "MyAnimeListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeGenres_Genres_GenreName",
                        column: x => x.GenreName,
                        principalTable: "Genres",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "AnimeProducers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeProducers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeProducers_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "MyAnimeListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeProducers_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "AnimesStudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    StudioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesStudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimesStudios_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "MyAnimeListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesStudios_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenres_AnimeId",
                table: "AnimeGenres",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenres_GenreName",
                table: "AnimeGenres",
                column: "GenreName");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeProducers_AnimeId",
                table: "AnimeProducers",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeProducers_ProducerId",
                table: "AnimeProducers",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeScores_MyAnimeListId",
                table: "AnimeScores",
                column: "MyAnimeListId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesStudios_AnimeId",
                table: "AnimesStudios",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesStudios_StudioId",
                table: "AnimesStudios",
                column: "StudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeGenres");

            migrationBuilder.DropTable(
                name: "AnimeProducers");

            migrationBuilder.DropTable(
                name: "AnimeScores");

            migrationBuilder.DropTable(
                name: "AnimesStudios");

            migrationBuilder.DropTable(
                name: "AnimesWithSynopsis");

            migrationBuilder.DropTable(
                name: "RatingCompletes");

            migrationBuilder.DropTable(
                name: "WatchStatus");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
