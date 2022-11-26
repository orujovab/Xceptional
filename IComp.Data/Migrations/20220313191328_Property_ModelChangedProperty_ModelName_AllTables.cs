using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class Property_ModelChangedProperty_ModelName_AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "VideoCards");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "ProdMemories");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "HardDiscs");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "VideoCards",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "ProdMemories",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "Processors",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "MotherBoards",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "HardDiscs",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "VideoCards");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "ProdMemories");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "HardDiscs");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "VideoCards",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "ProdMemories",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Processors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "MotherBoards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "HardDiscs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
