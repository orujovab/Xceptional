using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class HardDiscTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HDDCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<string>(maxLength: 100, nullable: false),
                    CycleRate = table.Column<string>(maxLength: 100, nullable: false),
                    IsSSD = table.Column<bool>(nullable: false, defaultValue: false),
                    IsHDD = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardDiscs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    HDDCapacityId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 150, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false, defaultValue: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDiscs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardDiscs_HDDCapacities_HDDCapacityId",
                        column: x => x.HDDCapacityId,
                        principalTable: "HDDCapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardDiscs_HDDCapacityId",
                table: "HardDiscs",
                column: "HDDCapacityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardDiscs");

            migrationBuilder.DropTable(
                name: "HDDCapacities");
        }
    }
}
