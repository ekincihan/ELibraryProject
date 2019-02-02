using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class userrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRates",
                columns: table => new
                {
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    Rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRates");
        }
    }
}
