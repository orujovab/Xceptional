using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class BrandTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "procSpeed",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Brands",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "procSpeed",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
