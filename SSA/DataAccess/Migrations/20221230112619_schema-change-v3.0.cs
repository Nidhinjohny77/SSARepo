using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class schemachangev30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_PropertyUID",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "PropertyImage");

            migrationBuilder.AddColumn<int>(
                name: "ImageFileTypeUID",
                table: "PropertyImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageTypeUID",
                table: "PropertyImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.UID);
                });

            migrationBuilder.InsertData(
                table: "ImageFileType",
                columns: new[] { "UID", "Name" },
                values: new object[] { 1, "jpeg" });

            migrationBuilder.InsertData(
                table: "ImageType",
                columns: new[] { "UID", "Name" },
                values: new object[] { 1, "ThumbNail" });

            migrationBuilder.InsertData(
                table: "ImageType",
                columns: new[] { "UID", "Name" },
                values: new object[] { 2, "Full" });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_ImageFileTypeUID",
                table: "PropertyImage",
                column: "ImageFileTypeUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_ImageTypeUID",
                table: "PropertyImage",
                column: "ImageTypeUID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_ImageFileType_ImageFileTypeUID",
                table: "PropertyImage",
                column: "ImageFileTypeUID",
                principalTable: "ImageFileType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_ImageType_ImageTypeUID",
                table: "PropertyImage",
                column: "ImageTypeUID",
                principalTable: "ImageType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_PropertyUID",
                table: "PropertyImage",
                column: "PropertyUID",
                principalTable: "Property",
                principalColumn: "UID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_ImageFileType_ImageFileTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_ImageType_ImageTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_Property_PropertyUID",
                table: "PropertyImage");

            migrationBuilder.DropTable(
                name: "ImageFileType");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_ImageFileTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_ImageTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "ImageFileTypeUID",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "ImageTypeUID",
                table: "PropertyImage");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_Property_PropertyUID",
                table: "PropertyImage",
                column: "PropertyUID",
                principalTable: "Property",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
