using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class ECD_EnitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorPhoto",
                table: "Authors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Authors",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BookName = table.Column<string>(maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    BookSummary = table.Column<string>(maxLength: 4000, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    NumberPages = table.Column<int>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    PublisherId = table.Column<Guid>(nullable: false),
                    BooksPhoto = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTagAssignments",
                columns: table => new
                {
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTagAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTagAssignments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTagAssignments_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTagAssignments_CategoryId",
                table: "CategoryTagAssignments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTagAssignments_TagId",
                table: "CategoryTagAssignments",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CategoryTagAssignments");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "AuthorPhoto",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Authors");
        }
    }
}
