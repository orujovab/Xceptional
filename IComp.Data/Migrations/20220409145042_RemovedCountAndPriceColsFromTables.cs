using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class RemovedCountAndPriceColsFromTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "VideoCards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "VideoCards");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "HardDiscs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HardDiscs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "VideoCards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "VideoCards",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "SSDs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "SSDs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Processors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Processors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "MotherBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MotherBoards",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "HardDiscs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "HardDiscs",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
