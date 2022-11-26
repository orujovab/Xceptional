using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class ProductTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HardDiscId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherBoardId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdMemoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdTypeId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoCardId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DestinationId",
                table: "Products",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_HardDiscId",
                table: "Products",
                column: "HardDiscId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MotherBoardId",
                table: "Products",
                column: "MotherBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdMemoryId",
                table: "Products",
                column: "ProdMemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdTypeId",
                table: "Products",
                column: "ProdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VideoCardId",
                table: "Products",
                column: "VideoCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Destinations_DestinationId",
                table: "Products",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_HardDiscs_HardDiscId",
                table: "Products",
                column: "HardDiscId",
                principalTable: "HardDiscs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MotherBoards_MotherBoardId",
                table: "Products",
                column: "MotherBoardId",
                principalTable: "MotherBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdMemories_ProdMemoryId",
                table: "Products",
                column: "ProdMemoryId",
                principalTable: "ProdMemories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdTypes_ProdTypeId",
                table: "Products",
                column: "ProdTypeId",
                principalTable: "ProdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VideoCards_VideoCardId",
                table: "Products",
                column: "VideoCardId",
                principalTable: "VideoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Destinations_DestinationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_HardDiscs_HardDiscId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MotherBoards_MotherBoardId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdMemories_ProdMemoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_ProdTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_VideoCards_VideoCardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DestinationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_HardDiscId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MotherBoardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdMemoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VideoCardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HardDiscId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MotherBoardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdMemoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VideoCardId",
                table: "Products");
        }
    }
}
