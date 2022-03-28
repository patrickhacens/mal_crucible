using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class Columnsnameschange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rating",
                table: "RatingCompletes",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "anime_id",
                table: "RatingCompletes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "synopsis",
                table: "AnimesWithSynopsis",
                newName: "Synopsis");

            migrationBuilder.RenameColumn(
                name: "genres",
                table: "AnimesWithSynopsis",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AnimeScores",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "AnimeScores",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "watching_status",
                table: "AnimeScores",
                newName: "WatchingStatus");

            migrationBuilder.RenameColumn(
                name: "watched_episodes",
                table: "AnimeScores",
                newName: "WatchedEpisodes");

            migrationBuilder.RenameColumn(
                name: "animeid",
                table: "AnimeScores",
                newName: "MyAnimeListId");

            migrationBuilder.RenameColumn(
                name: "watching",
                table: "Animes",
                newName: "Watching");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Animes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "studios",
                table: "Animes",
                newName: "Studios");

            migrationBuilder.RenameColumn(
                name: "source",
                table: "Animes",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "score10",
                table: "Animes",
                newName: "Score10");

            migrationBuilder.RenameColumn(
                name: "score09",
                table: "Animes",
                newName: "Score09");

            migrationBuilder.RenameColumn(
                name: "score08",
                table: "Animes",
                newName: "Score08");

            migrationBuilder.RenameColumn(
                name: "score07",
                table: "Animes",
                newName: "Score07");

            migrationBuilder.RenameColumn(
                name: "score06",
                table: "Animes",
                newName: "Score06");

            migrationBuilder.RenameColumn(
                name: "score05",
                table: "Animes",
                newName: "Score05");

            migrationBuilder.RenameColumn(
                name: "score04",
                table: "Animes",
                newName: "Score04");

            migrationBuilder.RenameColumn(
                name: "score03",
                table: "Animes",
                newName: "Score03");

            migrationBuilder.RenameColumn(
                name: "score02",
                table: "Animes",
                newName: "Score02");

            migrationBuilder.RenameColumn(
                name: "score01",
                table: "Animes",
                newName: "Score01");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "Animes",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "ranked",
                table: "Animes",
                newName: "Ranked");

            migrationBuilder.RenameColumn(
                name: "producers",
                table: "Animes",
                newName: "Producers");

            migrationBuilder.RenameColumn(
                name: "premiered",
                table: "Animes",
                newName: "Premiered");

            migrationBuilder.RenameColumn(
                name: "popularity",
                table: "Animes",
                newName: "Popularity");

            migrationBuilder.RenameColumn(
                name: "plantowatch",
                table: "Animes",
                newName: "PlanToWatch");

            migrationBuilder.RenameColumn(
                name: "onhold",
                table: "Animes",
                newName: "Onhold");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Animes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "members",
                table: "Animes",
                newName: "Members");

            migrationBuilder.RenameColumn(
                name: "licensors",
                table: "Animes",
                newName: "Licensors");

            migrationBuilder.RenameColumn(
                name: "japanesename",
                table: "Animes",
                newName: "JapaneseName");

            migrationBuilder.RenameColumn(
                name: "genres",
                table: "Animes",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "favorites",
                table: "Animes",
                newName: "Favorites");

            migrationBuilder.RenameColumn(
                name: "episodes",
                table: "Animes",
                newName: "Episodes");

            migrationBuilder.RenameColumn(
                name: "englishname",
                table: "Animes",
                newName: "EnglishName");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Animes",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "dropped",
                table: "Animes",
                newName: "Dropped");

            migrationBuilder.RenameColumn(
                name: "completed",
                table: "Animes",
                newName: "Completed");

            migrationBuilder.RenameColumn(
                name: "aired",
                table: "Animes",
                newName: "Aired");

            migrationBuilder.RenameColumn(
                name: "agerate",
                table: "Animes",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "MyAnimeListId",
                table: "RatingCompletes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "AnimesWithSynopsis",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AnimeScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyAnimeListId",
                table: "RatingCompletes");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "RatingCompletes",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RatingCompletes",
                newName: "anime_id");

            migrationBuilder.RenameColumn(
                name: "Synopsis",
                table: "AnimesWithSynopsis",
                newName: "synopsis");

            migrationBuilder.RenameColumn(
                name: "Genres",
                table: "AnimesWithSynopsis",
                newName: "genres");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AnimeScores",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "AnimeScores",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "WatchingStatus",
                table: "AnimeScores",
                newName: "watching_status");

            migrationBuilder.RenameColumn(
                name: "WatchedEpisodes",
                table: "AnimeScores",
                newName: "watched_episodes");

            migrationBuilder.RenameColumn(
                name: "MyAnimeListId",
                table: "AnimeScores",
                newName: "animeid");

            migrationBuilder.RenameColumn(
                name: "Watching",
                table: "Animes",
                newName: "watching");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Animes",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Studios",
                table: "Animes",
                newName: "studios");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Animes",
                newName: "source");

            migrationBuilder.RenameColumn(
                name: "Score10",
                table: "Animes",
                newName: "score10");

            migrationBuilder.RenameColumn(
                name: "Score09",
                table: "Animes",
                newName: "score09");

            migrationBuilder.RenameColumn(
                name: "Score08",
                table: "Animes",
                newName: "score08");

            migrationBuilder.RenameColumn(
                name: "Score07",
                table: "Animes",
                newName: "score07");

            migrationBuilder.RenameColumn(
                name: "Score06",
                table: "Animes",
                newName: "score06");

            migrationBuilder.RenameColumn(
                name: "Score05",
                table: "Animes",
                newName: "score05");

            migrationBuilder.RenameColumn(
                name: "Score04",
                table: "Animes",
                newName: "score04");

            migrationBuilder.RenameColumn(
                name: "Score03",
                table: "Animes",
                newName: "score03");

            migrationBuilder.RenameColumn(
                name: "Score02",
                table: "Animes",
                newName: "score02");

            migrationBuilder.RenameColumn(
                name: "Score01",
                table: "Animes",
                newName: "score01");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Animes",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "Ranked",
                table: "Animes",
                newName: "ranked");

            migrationBuilder.RenameColumn(
                name: "Producers",
                table: "Animes",
                newName: "producers");

            migrationBuilder.RenameColumn(
                name: "Premiered",
                table: "Animes",
                newName: "premiered");

            migrationBuilder.RenameColumn(
                name: "Popularity",
                table: "Animes",
                newName: "popularity");

            migrationBuilder.RenameColumn(
                name: "PlanToWatch",
                table: "Animes",
                newName: "plantowatch");

            migrationBuilder.RenameColumn(
                name: "Onhold",
                table: "Animes",
                newName: "onhold");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Animes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Members",
                table: "Animes",
                newName: "members");

            migrationBuilder.RenameColumn(
                name: "Licensors",
                table: "Animes",
                newName: "licensors");

            migrationBuilder.RenameColumn(
                name: "JapaneseName",
                table: "Animes",
                newName: "japanesename");

            migrationBuilder.RenameColumn(
                name: "Genres",
                table: "Animes",
                newName: "genres");

            migrationBuilder.RenameColumn(
                name: "Favorites",
                table: "Animes",
                newName: "favorites");

            migrationBuilder.RenameColumn(
                name: "Episodes",
                table: "Animes",
                newName: "episodes");

            migrationBuilder.RenameColumn(
                name: "EnglishName",
                table: "Animes",
                newName: "englishname");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Animes",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Dropped",
                table: "Animes",
                newName: "dropped");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "Animes",
                newName: "completed");

            migrationBuilder.RenameColumn(
                name: "Aired",
                table: "Animes",
                newName: "aired");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Animes",
                newName: "agerate");

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "AnimesWithSynopsis",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "score",
                table: "AnimeScores",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
