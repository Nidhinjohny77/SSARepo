using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddPropertyRelatedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyListing",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingAmount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Listedby = table.Column<int>(type: "int", nullable: false),
                    ListingStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyListing", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyListing_Property_PropertyUID",
                        column: x => x.PropertyUID,
                        principalTable: "Property",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyReview",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewerUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyReview", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyReview_Property_PropertyUID",
                        column: x => x.PropertyUID,
                        principalTable: "Property",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyRenting",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyListingUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentAmount = table.Column<double>(type: "float", nullable: false),
                    AdvanceAmount = table.Column<double>(type: "float", nullable: false),
                    RentedUserUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentPaymentFrequency = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyRenting", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyRenting_PropertyListing_PropertyListingUID",
                        column: x => x.PropertyListingUID,
                        principalTable: "PropertyListing",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyViewing",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyListingUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyViewing", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyViewing_PropertyListing_PropertyListingUID",
                        column: x => x.PropertyListingUID,
                        principalTable: "PropertyListing",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListing_PropertyUID",
                table: "PropertyListing",
                column: "PropertyUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRenting_PropertyListingUID",
                table: "PropertyRenting",
                column: "PropertyListingUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyReview_PropertyUID",
                table: "PropertyReview",
                column: "PropertyUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyViewing_PropertyListingUID",
                table: "PropertyViewing",
                column: "PropertyListingUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyRenting");

            migrationBuilder.DropTable(
                name: "PropertyReview");

            migrationBuilder.DropTable(
                name: "PropertyViewing");

            migrationBuilder.DropTable(
                name: "PropertyListing");
        }
    }
}
