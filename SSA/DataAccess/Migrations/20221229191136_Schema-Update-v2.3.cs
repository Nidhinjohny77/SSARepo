using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SchemaUpdatev23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Listedby",
                table: "PropertyListing");

            migrationBuilder.DropColumn(
                name: "ListingStatus",
                table: "PropertyListing");

            migrationBuilder.AddColumn<string>(
                name: "ListedByUser",
                table: "PropertyListing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListedByUser",
                table: "PropertyListing");

            migrationBuilder.AddColumn<int>(
                name: "Listedby",
                table: "PropertyListing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListingStatus",
                table: "PropertyListing",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
