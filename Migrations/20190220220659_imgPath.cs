using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMyStories.Migrations
{
    public partial class imgPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgPath",
                table: "story",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgPath",
                table: "story");
        }
    }
}
