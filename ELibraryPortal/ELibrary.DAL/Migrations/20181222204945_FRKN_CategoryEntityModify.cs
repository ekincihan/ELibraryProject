using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.DAL.Migrations
{
    public partial class FRKN_CategoryEntityModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "CategoryTagAssignments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppTypeId",
                table: "Categories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTagAssignments_BookId",
                table: "CategoryTagAssignments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AppTypeId",
                table: "Categories",
                column: "AppTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Types_AppTypeId",
                table: "Categories",
                column: "AppTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTagAssignments_Books_BookId",
                table: "CategoryTagAssignments",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Types_AppTypeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTagAssignments_Books_BookId",
                table: "CategoryTagAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTagAssignments_BookId",
                table: "CategoryTagAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AppTypeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "CategoryTagAssignments");

            migrationBuilder.DropColumn(
                name: "AppTypeId",
                table: "Categories");
        }
    }
}
