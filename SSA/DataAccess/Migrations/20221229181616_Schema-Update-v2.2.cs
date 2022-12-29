using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SchemaUpdatev22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Property_LandlordUID",
                table: "Property");

            migrationBuilder.AddColumn<int>(
                name: "CountryUID",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Property_CountryUID",
                table: "Property",
                column: "CountryUID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_LandlordUID",
                table: "Property",
                column: "LandlordUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Country_CountryUID",
                table: "Property",
                column: "CountryUID",
                principalTable: "Country",
                principalColumn: "UID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Country_CountryUID",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_CountryUID",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_LandlordUID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "CountryUID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Property");

            migrationBuilder.CreateIndex(
                name: "IX_Property_LandlordUID",
                table: "Property",
                column: "LandlordUID",
                unique: true);
        }
    }
}
