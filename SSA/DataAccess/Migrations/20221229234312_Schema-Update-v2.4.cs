using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SchemaUpdatev24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_ImageFile_ImageFileUID",
                table: "PropertyImage");

            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_ImageFileUID",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "ImageFileUID",
                table: "PropertyImage");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "PropertyImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileUID",
                table: "PropertyImage",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.UID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_ImageFileUID",
                table: "PropertyImage",
                column: "ImageFileUID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_ImageFile_ImageFileUID",
                table: "PropertyImage",
                column: "ImageFileUID",
                principalTable: "ImageFile",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
