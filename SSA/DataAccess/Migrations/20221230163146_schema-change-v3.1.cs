using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class schemachangev31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_ImageFileType_ImageFileTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropTable(
                name: "ImageFileType");

            migrationBuilder.RenameColumn(
                name: "ImageFileTypeUID",
                table: "PropertyImage",
                newName: "FileTypeUID");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyImage_ImageFileTypeUID",
                table: "PropertyImage",
                newName: "IX_PropertyImage_FileTypeUID");

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.UID);
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "UID", "Description", "Name" },
                values: new object[] { 1, "this type is used for storing images.", "jpeg" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_FileType_FileTypeUID",
                table: "PropertyImage",
                column: "FileTypeUID",
                principalTable: "FileType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_FileType_FileTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.RenameColumn(
                name: "FileTypeUID",
                table: "PropertyImage",
                newName: "ImageFileTypeUID");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyImage_FileTypeUID",
                table: "PropertyImage",
                newName: "IX_PropertyImage_ImageFileTypeUID");

            migrationBuilder.CreateTable(
                name: "ImageFileType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFileType", x => x.UID);
                });

            migrationBuilder.InsertData(
                table: "ImageFileType",
                columns: new[] { "UID", "Name" },
                values: new object[] { 1, "jpeg" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_ImageFileType_ImageFileTypeUID",
                table: "PropertyImage",
                column: "ImageFileTypeUID",
                principalTable: "ImageFileType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
