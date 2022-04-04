using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class ProducersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producers",
                table: "Animes");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Animes_MyAnimeListId",
                table: "Animes",
                column: "MyAnimeListId");

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeProducers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeProducers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeProducers_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeProducers_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeScores_MyAnimeListId",
                table: "AnimeScores",
                column: "MyAnimeListId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeProducers_AnimeId",
                table: "AnimeProducers",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeProducers_ProducerId",
                table: "AnimeProducers",
                column: "ProducerId");

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
                name: "AnimeProducers");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_AnimeScores_MyAnimeListId",
                table: "AnimeScores");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Animes_MyAnimeListId",
                table: "Animes");

            migrationBuilder.AddColumn<string>(
                name: "Producers",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
