using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class SSDTableCreatedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SSDId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SSDCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<string>(maxLength: 100, nullable: false),
                    CycleRate = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    SSDCapacityID = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(maxLength: 100, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SSDs_SSDCapacities_SSDCapacityID",
                        column: x => x.SSDCapacityID,
                        principalTable: "SSDCapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SSDId",
                table: "Products",
                column: "SSDId");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_SSDCapacityID",
                table: "SSDs",
                column: "SSDCapacityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SSDs_SSDId",
                table: "Products",
                column: "SSDId",
                principalTable: "SSDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SSDs_SSDId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SSDs");

            migrationBuilder.DropTable(
                name: "SSDCapacities");

            migrationBuilder.DropIndex(
                name: "IX_Products_SSDId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SSDId",
                table: "Products");
        }
    }
}
