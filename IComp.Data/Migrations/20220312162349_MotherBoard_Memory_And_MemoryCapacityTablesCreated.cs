using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class MotherBoard_Memory_And_MemoryCapacityTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemoryCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotherBoards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Model = table.Column<string>(maxLength: 100, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false, defaultValue: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdMemories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    MemoryCapacityId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(maxLength: 150, nullable: false),
                    Speed = table.Column<string>(maxLength: 50, nullable: false),
                    DDRType = table.Column<string>(maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false, defaultValue: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdMemories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdMemories_MemoryCapacities_MemoryCapacityId",
                        column: x => x.MemoryCapacityId,
                        principalTable: "MemoryCapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdMemories_MemoryCapacityId",
                table: "ProdMemories",
                column: "MemoryCapacityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotherBoards");

            migrationBuilder.DropTable(
                name: "ProdMemories");

            migrationBuilder.DropTable(
                name: "MemoryCapacities");
        }
    }
}
