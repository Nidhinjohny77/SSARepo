using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SchemaUpdatev21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Landlord_LandlordProfileUID",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "LandlordProfileUID",
                table: "Property",
                newName: "LandlordUID");

            migrationBuilder.RenameIndex(
                name: "IX_Property_LandlordProfileUID",
                table: "Property",
                newName: "IX_Property_LandlordUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Landlord_LandlordUID",
                table: "Property",
                column: "LandlordUID",
                principalTable: "Landlord",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Landlord_LandlordUID",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "LandlordUID",
                table: "Property",
                newName: "LandlordProfileUID");

            migrationBuilder.RenameIndex(
                name: "IX_Property_LandlordUID",
                table: "Property",
                newName: "IX_Property_LandlordProfileUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Landlord_LandlordProfileUID",
                table: "Property",
                column: "LandlordProfileUID",
                principalTable: "Landlord",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
