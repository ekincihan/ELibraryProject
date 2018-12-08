using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class esatavsar_Publisher_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Publishers",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Publishers");
        }
    }
}
