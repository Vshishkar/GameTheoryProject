using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTheoryProject.Migrations
{
    public partial class IsWinnerWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWinner",
                table: "UserGameResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWinner",
                table: "UserGameResponses");
        }
    }
}
