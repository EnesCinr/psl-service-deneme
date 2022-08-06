using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSL.DataAccess.Migrations
{
    public partial class devicetablerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "SubType",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Devices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeviceTypeId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeviceTypeClassificationRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false),
                    DeviceTypeClassification = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeClassificationRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypeClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypeClassificationSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false),
                    DeviceTypeClassificationId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeClassificationSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceTypeClassificationSelections_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypeClassificationSelections_DeviceId",
                table: "DeviceTypeClassificationSelections",
                column: "DeviceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceTypeId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceTypeClassificationRelations");

            migrationBuilder.DropTable(
                name: "DeviceTypeClassifications");

            migrationBuilder.DropTable(
                name: "DeviceTypeClassificationSelections");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceTypeId",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubType",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
