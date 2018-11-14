using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Data.Migrations
{
    public partial class modifiedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdentityUserId",
                table: "Subcategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Subcategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentityUserId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentityUserId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_IdentityUserId1",
                table: "Subcategories",
                column: "IdentityUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdentityUserId1",
                table: "Products",
                column: "IdentityUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IdentityUserId1",
                table: "Categories",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_IdentityUserId1",
                table: "Categories",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_IdentityUserId1",
                table: "Products",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_AspNetUsers_IdentityUserId1",
                table: "Subcategories",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_IdentityUserId1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_IdentityUserId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_AspNetUsers_IdentityUserId1",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Subcategories_IdentityUserId1",
                table: "Subcategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdentityUserId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IdentityUserId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Categories");
        }
    }
}
