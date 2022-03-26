using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class DroppedWatchStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchStatus",
                columns: table => new
                {
                    x = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
