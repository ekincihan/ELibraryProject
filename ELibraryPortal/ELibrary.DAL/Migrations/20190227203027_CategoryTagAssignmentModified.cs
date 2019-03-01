using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class CategoryTagAssignmentModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagId",
                table: "CategoryTagAssigments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "CategoryTagAssigments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagId",
                table: "CategoryTagAssigments");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "CategoryTagAssigments");
        }
    }
}
