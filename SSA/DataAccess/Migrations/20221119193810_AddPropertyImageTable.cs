using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddPropertyImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageFileUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyImage_ImageFile_ImageFileUID",
                        column: x => x.ImageFileUID,
                        principalTable: "ImageFile",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Property_PropertyUID",
                        column: x => x.PropertyUID,
                        principalTable: "Property",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_ImageFileUID",
                table: "PropertyImage",
                column: "ImageFileUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyUID",
                table: "PropertyImage",
                column: "PropertyUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");
        }
    }
}
