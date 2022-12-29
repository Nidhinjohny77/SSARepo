using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SchemaUpdatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Landlord");

            migrationBuilder.RenameColumn(
                name: "ProfileUID",
                table: "Landlord",
                newName: "UID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Landlord",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CountryUID",
                table: "Landlord",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_CountryUID",
                table: "Landlord",
                column: "CountryUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlord_Country_CountryUID",
                table: "Landlord",
                column: "CountryUID",
                principalTable: "Country",
                principalColumn: "UID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlord_Country_CountryUID",
                table: "Landlord");

            migrationBuilder.DropIndex(
                name: "IX_Landlord_CountryUID",
                table: "Landlord");

            migrationBuilder.DropColumn(
                name: "CountryUID",
                table: "Landlord");

            migrationBuilder.RenameColumn(
                name: "UID",
                table: "Landlord",
                newName: "ProfileUID");

            migrationBuilder.AlterColumn<string>(
                name: "DOB",
                table: "Landlord",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Landlord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
