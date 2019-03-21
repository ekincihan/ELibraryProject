using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class frkn_BannerEntityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendUrl",
                table: "Banners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SendUrl",
                table: "Banners",
                nullable: true);
        }
    }
}
