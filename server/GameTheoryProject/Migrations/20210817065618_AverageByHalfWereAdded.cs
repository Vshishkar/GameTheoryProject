using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTheoryProject.Migrations
{
    public partial class AverageByHalfWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageByHalf",
                table: "Games",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageByHalf",
                table: "Games");
        }
    }
}
