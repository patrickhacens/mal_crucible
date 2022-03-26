using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAnimeList.Migrations
{
    public partial class FiledNameAddedtoTableAnimeWithSynopsis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "AnimesWithSynopsis",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AnimesWithSynopsis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AnimesWithSynopsis");

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "AnimesWithSynopsis",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
