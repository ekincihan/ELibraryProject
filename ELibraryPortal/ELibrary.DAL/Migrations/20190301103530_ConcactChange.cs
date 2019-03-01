using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class ConcactChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhonuNumber",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteMail",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhonuNumber",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SiteMail",
                table: "Contacts");
        }
    }
}
