using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class FRKN_AuthorModelModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTagAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Authors",
                maxLength: 10000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Authors",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryTagAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTagAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTagAssignments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CategoryTagAssignments_BookId",
                table: "CategoryTagAssignments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTagAssignments_CategoryId",
                table: "CategoryTagAssignments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTagAssignments_TagId",
                table: "CategoryTagAssignments",
                column: "TagId");
        }
    }
}
