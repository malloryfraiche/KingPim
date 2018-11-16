using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Data.Migrations
{
    public partial class predefinedList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PredefinedListId",
                table: "ProductAttributes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PredefinedLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedListOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PredefinedListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedListOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredefinedListOptions_PredefinedLists_PredefinedListId",
                        column: x => x.PredefinedListId,
                        principalTable: "PredefinedLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_PredefinedListId",
                table: "ProductAttributes",
                column: "PredefinedListId");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedListOptions_PredefinedListId",
                table: "PredefinedListOptions",
                column: "PredefinedListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_PredefinedLists_PredefinedListId",
                table: "ProductAttributes",
                column: "PredefinedListId",
                principalTable: "PredefinedLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_PredefinedLists_PredefinedListId",
                table: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "PredefinedListOptions");

            migrationBuilder.DropTable(
                name: "PredefinedLists");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_PredefinedListId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "PredefinedListId",
                table: "ProductAttributes");
        }
    }
}
