using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class ProductTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_HardDiscs_HardDiscId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "HardDiscId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_HardDiscs_HardDiscId",
                table: "Products",
                column: "HardDiscId",
                principalTable: "HardDiscs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_HardDiscs_HardDiscId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "HardDiscId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_HardDiscs_HardDiscId",
                table: "Products",
                column: "HardDiscId",
                principalTable: "HardDiscs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
