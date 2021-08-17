using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTheoryProject.Migrations
{
    public partial class WinningNumberWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinningNumber",
                table: "Games",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinningNumber",
                table: "Games");
        }
    }
}
