using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyAnimeListId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    englishname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    japanesename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episodes = table.Column<int>(type: "int", nullable: false),
                    aired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    premiered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licensors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    agerate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ranked = table.Column<int>(type: "int", nullable: false),
                    popularity = table.Column<int>(type: "int", nullable: false),
                    members = table.Column<int>(type: "int", nullable: false),
                    favorites = table.Column<int>(type: "int", nullable: false),
                    watching = table.Column<int>(type: "int", nullable: false),
                    completed = table.Column<int>(type: "int", nullable: false),
                    onhold = table.Column<int>(type: "int", nullable: false),
                    dropped = table.Column<int>(type: "int", nullable: false),
                    plantowatch = table.Column<int>(type: "int", nullable: false),
                    score10 = table.Column<int>(type: "int", nullable: false),
                    score09 = table.Column<int>(type: "int", nullable: false),
                    score08 = table.Column<int>(type: "int", nullable: false),
                    score07 = table.Column<int>(type: "int", nullable: false),
                    score06 = table.Column<int>(type: "int", nullable: false),
                    score05 = table.Column<int>(type: "int", nullable: false),
                    score04 = table.Column<int>(type: "int", nullable: false),
                    score03 = table.Column<int>(type: "int", nullable: false),
                    score02 = table.Column<int>(type: "int", nullable: false),
                    score01 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    animeid = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    watching_status = table.Column<int>(type: "int", nullable: false),
                    watched_episodes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimesWithSynopsis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyAnimeListId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesWithSynopsis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingFromCompletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anime_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFromCompletes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchStatuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "AnimeScores");

            migrationBuilder.DropTable(
                name: "AnimesWithSynopsis");

            migrationBuilder.DropTable(
                name: "RatingFromCompletes");

            migrationBuilder.DropTable(
                name: "WatchStatuses");
        }
    }
}
