using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class CheckedProductsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checked",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CheckedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckedProducts");

            migrationBuilder.AddColumn<bool>(
                name: "Checked",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
