using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SchemaUpdatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyListingAttribute_TenancyType_TenantTypeUID",
                table: "PropertyListingAttribute");

            migrationBuilder.RenameColumn(
                name: "PreferedTenancyPeriod",
                table: "TenantPreference",
                newName: "PreferedTenancyPeriodInMonths");

            migrationBuilder.RenameColumn(
                name: "TenantTypeUID",
                table: "PropertyListingAttribute",
                newName: "TenancyTypeUID");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyListingAttribute_TenantTypeUID",
                table: "PropertyListingAttribute",
                newName: "IX_PropertyListingAttribute_TenancyTypeUID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "PropertyListingAttribute",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "PropertyAttribute",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaxOccupantCount",
                table: "PropertyAttribute",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyListingAttribute_TenancyType_TenancyTypeUID",
                table: "PropertyListingAttribute",
                column: "TenancyTypeUID",
                principalTable: "TenancyType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyListingAttribute_TenancyType_TenancyTypeUID",
                table: "PropertyListingAttribute");

            migrationBuilder.DropColumn(
                name: "MaxOccupantCount",
                table: "PropertyAttribute");

            migrationBuilder.RenameColumn(
                name: "PreferedTenancyPeriodInMonths",
                table: "TenantPreference",
                newName: "PreferedTenancyPeriod");

            migrationBuilder.RenameColumn(
                name: "TenancyTypeUID",
                table: "PropertyListingAttribute",
                newName: "TenantTypeUID");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyListingAttribute_TenancyTypeUID",
                table: "PropertyListingAttribute",
                newName: "IX_PropertyListingAttribute_TenantTypeUID");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedDate",
                table: "PropertyListingAttribute",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedDate",
                table: "PropertyAttribute",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyListingAttribute_TenancyType_TenantTypeUID",
                table: "PropertyListingAttribute",
                column: "TenantTypeUID",
                principalTable: "TenancyType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
