using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class AllIdsfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animes",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Producers",
                table: "Animes");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateAired",
                table: "Animes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateAired",
                table: "Animes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animes",
                table: "Animes",
                column: "MyAnimeListId");

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
                name: "IX_AnimeScores_MyAnimeListId",
                table: "AnimeScores",
                column: "MyAnimeListId");

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
                name: "IX_AnimesStudios_AnimeId",
                table: "AnimesStudios",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesStudios_StudioId",
                table: "AnimesStudios",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeScores_Animes_MyAnimeListId",
                table: "AnimeScores",
                column: "MyAnimeListId",
                principalTable: "Animes",
                principalColumn: "MyAnimeListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeScores_Animes_MyAnimeListId",
                table: "AnimeScores");

            migrationBuilder.DropTable(
                name: "AnimeGenres");

            migrationBuilder.DropTable(
                name: "AnimeProducers");

            migrationBuilder.DropTable(
                name: "AnimesStudios");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropIndex(
                name: "IX_AnimeScores_MyAnimeListId",
                table: "AnimeScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animes",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "EndDateAired",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "StartDateAired",
                table: "Animes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Producers",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animes",
                table: "Animes",
                column: "Id");
        }
    }
}
