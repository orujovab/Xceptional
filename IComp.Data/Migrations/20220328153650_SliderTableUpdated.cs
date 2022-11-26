using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class SliderTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirst",
                table: "Sliders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecond",
                table: "Sliders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirst",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsSecond",
                table: "Sliders");
        }
    }
}
