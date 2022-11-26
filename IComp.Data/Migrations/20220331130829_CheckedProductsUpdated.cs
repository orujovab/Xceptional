using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class CheckedProductsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CheckedProducts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckedProducts_AppUserId",
                table: "CheckedProducts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckedProducts_ProductId",
                table: "CheckedProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckedProducts_AspNetUsers_AppUserId",
                table: "CheckedProducts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckedProducts_Products_ProductId",
                table: "CheckedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckedProducts_AspNetUsers_AppUserId",
                table: "CheckedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckedProducts_Products_ProductId",
                table: "CheckedProducts");

            migrationBuilder.DropIndex(
                name: "IX_CheckedProducts_AppUserId",
                table: "CheckedProducts");

            migrationBuilder.DropIndex(
                name: "IX_CheckedProducts_ProductId",
                table: "CheckedProducts");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CheckedProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
