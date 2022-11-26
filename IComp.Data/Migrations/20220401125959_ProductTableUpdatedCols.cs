using Microsoft.EntityFrameworkCore.Migrations;

namespace IComp.Data.Migrations
{
    public partial class ProductTableUpdatedCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Destinations_DestinationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MotherBoards_MotherBoardId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Processors_ProcessorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdMemories_ProdMemoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_ProdTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Softwares_SoftwareId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_VideoCards_VideoCardId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "WarrantyPeriod",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "VideoCardId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "USBTypeC",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "USB",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SoundType",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "SoftwareId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProdTypeId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProdMemoryId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PowerSupply",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Network",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "MotherBoardId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "InputPorts",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "GraphCard",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaxResolution",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherBoardSound",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ports",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RamLightning",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speed",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "procSpeed",
                table: "Products",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Destinations_DestinationId",
                table: "Products",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MotherBoards_MotherBoardId",
                table: "Products",
                column: "MotherBoardId",
                principalTable: "MotherBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Processors_ProcessorId",
                table: "Products",
                column: "ProcessorId",
                principalTable: "Processors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdMemories_ProdMemoryId",
                table: "Products",
                column: "ProdMemoryId",
                principalTable: "ProdMemories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdTypes_ProdTypeId",
                table: "Products",
                column: "ProdTypeId",
                principalTable: "ProdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Softwares_SoftwareId",
                table: "Products",
                column: "SoftwareId",
                principalTable: "Softwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VideoCards_VideoCardId",
                table: "Products",
                column: "VideoCardId",
                principalTable: "VideoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Destinations_DestinationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MotherBoards_MotherBoardId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Processors_ProcessorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdMemories_ProdMemoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProdTypes_ProdTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Softwares_SoftwareId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_VideoCards_VideoCardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GraphCard",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxResolution",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MotherBoardSound",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ports",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RamLightning",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "procSpeed",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WarrantyPeriod",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VideoCardId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USBTypeC",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USB",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoundType",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoftwareId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdMemoryId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PowerSupply",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Network",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotherBoardId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InputPorts",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Destinations_DestinationId",
                table: "Products",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MotherBoards_MotherBoardId",
                table: "Products",
                column: "MotherBoardId",
                principalTable: "MotherBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Processors_ProcessorId",
                table: "Products",
                column: "ProcessorId",
                principalTable: "Processors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdMemories_ProdMemoryId",
                table: "Products",
                column: "ProdMemoryId",
                principalTable: "ProdMemories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProdTypes_ProdTypeId",
                table: "Products",
                column: "ProdTypeId",
                principalTable: "ProdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Softwares_SoftwareId",
                table: "Products",
                column: "SoftwareId",
                principalTable: "Softwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VideoCards_VideoCardId",
                table: "Products",
                column: "VideoCardId",
                principalTable: "VideoCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
