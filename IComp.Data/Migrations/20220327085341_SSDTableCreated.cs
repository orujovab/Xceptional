using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class SSDTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHDD",
                table: "HDDCapacities");

            migrationBuilder.DropColumn(
                name: "IsSSD",
                table: "HDDCapacities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHDD",
                table: "HDDCapacities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSSD",
                table: "HDDCapacities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
