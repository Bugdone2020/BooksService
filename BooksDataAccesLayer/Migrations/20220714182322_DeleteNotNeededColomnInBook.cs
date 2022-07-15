using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksDataAccesLayer.Migrations
{
    public partial class DeleteNotNeededColomnInBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
