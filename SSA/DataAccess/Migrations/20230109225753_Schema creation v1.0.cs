using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Schemacreationv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.UID);
                });

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

            migrationBuilder.CreateTable(
                name: "FurnishType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnishType", x => x.UID);
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

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "TenancyType",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenancyType", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyUID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Country_Currency_CurrencyUID",
                        column: x => x.CurrencyUID,
                        principalTable: "Currency",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemTypeUID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_ItemTypeUID",
                        column: x => x.ItemTypeUID,
                        principalTable: "ItemType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleUID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UID);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleUID",
                        column: x => x.RoleUID,
                        principalTable: "Role",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryUID = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.UID);
                    table.ForeignKey(
                        name: "FK_University_Country_CountryUID",
                        column: x => x.CountryUID,
                        principalTable: "Country",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Landlord",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryUID = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlord", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Landlord_Country_CountryUID",
                        column: x => x.CountryUID,
                        principalTable: "Country",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_Landlord_User_UserUID",
                        column: x => x.UserUID,
                        principalTable: "User",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryUID = table.Column<int>(type: "int", nullable: false),
                    TenancyTypeUID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Tenant_Country_CountryUID",
                        column: x => x.CountryUID,
                        principalTable: "Country",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenant_TenancyType_TenancyTypeUID",
                        column: x => x.TenancyTypeUID,
                        principalTable: "TenancyType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenant_User_UserUID",
                        column: x => x.UserUID,
                        principalTable: "User",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LandlordUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryUID = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Property_Country_CountryUID",
                        column: x => x.CountryUID,
                        principalTable: "Country",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_Property_Landlord_LandlordUID",
                        column: x => x.LandlordUID,
                        principalTable: "Landlord",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfile",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniversityStudentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentSecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrolledCourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityUID = table.Column<int>(type: "int", nullable: false),
                    CourseStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfile", x => x.UID);
                    table.ForeignKey(
                        name: "FK_StudentProfile_Tenant_TenantUID",
                        column: x => x.TenantUID,
                        principalTable: "Tenant",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProfile_University_UniversityUID",
                        column: x => x.UniversityUID,
                        principalTable: "University",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "TenantPreference",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyTypeUID = table.Column<int>(type: "int", nullable: false),
                    FurnishTypeUID = table.Column<int>(type: "int", nullable: false),
                    PreferedTenancyTypeUID = table.Column<int>(type: "int", nullable: true),
                    PreferedBedRoomCount = table.Column<int>(type: "int", nullable: true),
                    PreferedBathRoomCount = table.Column<int>(type: "int", nullable: true),
                    PreferedOccupantCount = table.Column<int>(type: "int", nullable: true),
                    IsSharingPrefered = table.Column<bool>(type: "bit", nullable: true),
                    IsAttachedBathroomPrefered = table.Column<bool>(type: "bit", nullable: true),
                    IsRentIncludingBillsPrefered = table.Column<bool>(type: "bit", nullable: true),
                    PreferedTenancyPeriodInMonths = table.Column<int>(type: "int", nullable: true),
                    PreferedLocations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartRangeAmount = table.Column<double>(type: "float", nullable: true),
                    EndRangeAmount = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantPreference", x => x.UID);
                    table.ForeignKey(
                        name: "FK_TenantPreference_FurnishType_FurnishTypeUID",
                        column: x => x.FurnishTypeUID,
                        principalTable: "FurnishType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantPreference_PropertyType_PropertyTypeUID",
                        column: x => x.PropertyTypeUID,
                        principalTable: "PropertyType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantPreference_Tenant_TenantUID",
                        column: x => x.TenantUID,
                        principalTable: "Tenant",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAttribute",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyTypeUID = table.Column<int>(type: "int", nullable: false),
                    FurnishTypeUID = table.Column<int>(type: "int", nullable: false),
                    BedroomCount = table.Column<int>(type: "int", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    MaxOccupantCount = table.Column<int>(type: "int", nullable: false),
                    TotalAreaInSqFT = table.Column<float>(type: "real", nullable: true),
                    IsBackyardAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsGarageAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsParkingSlotAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSlotCount = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAttribute", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyAttribute_Property_PropertyUID",
                        column: x => x.PropertyUID,
                        principalTable: "Property",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAttribute_PropertyType_PropertyTypeUID",
                        column: x => x.PropertyTypeUID,
                        principalTable: "PropertyType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTypeUID = table.Column<int>(type: "int", nullable: false),
                    FileTypeUID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyImage_FileType_FileTypeUID",
                        column: x => x.FileTypeUID,
                        principalTable: "FileType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyImage_ImageType_ImageTypeUID",
                        column: x => x.ImageTypeUID,
                        principalTable: "ImageType",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Property_PropertyUID",
                        column: x => x.PropertyUID,
                        principalTable: "Property",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "PropertyListing",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingAmount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCTIAvailableForSale = table.Column<bool>(type: "bit", nullable: false),
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
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "PropertyListingAttribute",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyListingUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyAttributeUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableBedroomCount = table.Column<int>(type: "int", nullable: false),
                    AvailableBathroomCount = table.Column<int>(type: "int", nullable: false),
                    AllowedOccupantCount = table.Column<int>(type: "int", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsStudentFriendly = table.Column<bool>(type: "bit", nullable: false),
                    IsSharingAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsUnisex = table.Column<bool>(type: "bit", nullable: false),
                    IsPetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsChildrenAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsSmokingAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsPartyingAllowed = table.Column<bool>(type: "bit", nullable: false),
                    IsParkingAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TenancyTypeUID = table.Column<int>(type: "int", nullable: false),
                    AvailableParkingSlots = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyListingAttribute", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PropertyListingAttribute_PropertyAttribute_PropertyAttributeUID",
                        column: x => x.PropertyAttributeUID,
                        principalTable: "PropertyAttribute",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyListingAttribute_PropertyListing_PropertyListingUID",
                        column: x => x.PropertyListingUID,
                        principalTable: "PropertyListing",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_PropertyListingAttribute_TenancyType_TenancyTypeUID",
                        column: x => x.TenancyTypeUID,
                        principalTable: "TenancyType",
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
                    TenantUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_PropertyRenting_Tenant_TenantUID",
                        column: x => x.TenantUID,
                        principalTable: "Tenant",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "PropertyViewing",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyListingUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_PropertyViewing_Tenant_TenantUID",
                        column: x => x.TenantUID,
                        principalTable: "Tenant",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "TenantItem",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyRentingUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemUID = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyUID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantItem", x => x.UID);
                    table.ForeignKey(
                        name: "FK_TenantItem_Currency_CurrencyUID",
                        column: x => x.CurrencyUID,
                        principalTable: "Currency",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantItem_Item_ItemUID",
                        column: x => x.ItemUID,
                        principalTable: "Item",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantItem_PropertyRenting_PropertyRentingUID",
                        column: x => x.PropertyRentingUID,
                        principalTable: "PropertyRenting",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "UID", "Code", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "INR", "Rupee", "" },
                    { 2, "GBP", "Pound", "" },
                    { 3, "BDT", "Bangladeshi Taka", "" },
                    { 4, "LKR", "Sri Lankan Rupee", "" },
                    { 5, "PKR", "Pakistani Rupee", "" },
                    { 6, "CNY", "Chinese Yuan", "" },
                    { 7, "EUR", "Euro", "" }
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "UID", "Description", "Name" },
                values: new object[] { 1, "this type is used for storing images.", "jpeg" });

            migrationBuilder.InsertData(
                table: "FurnishType",
                columns: new[] { "UID", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "FULL", "Fully Furnished" },
                    { 2, "SEMI", "Semi Furnished" },
                    { 3, "NF", "Non Furnished" }
                });

            migrationBuilder.InsertData(
                table: "ImageType",
                columns: new[] { "UID", "Name" },
                values: new object[,]
                {
                    { 1, "ThumbNail" },
                    { 2, "Full" }
                });

            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "UID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Furnitures available.", "Furniture" },
                    { 2, "Electrical items available.", "Electrical" },
                    { 3, "Equipments to deal the cooking gas.", "Gas Equipment" },
                    { 4, "Kitchen utensils,sink.", "Kitchen" },
                    { 5, "Bathroom fittings.", "Bathroom Fittings" },
                    { 6, "Heating fittings.", "Heat Fittings" }
                });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "UID", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "FLT", "Flat" },
                    { 2, "HSTL", "Hostel" },
                    { 3, "PG", "Paying Guest" },
                    { 4, "HSO", "House in Single Occupancy" },
                    { 5, "HMO", "House in Multiple Occupancy" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "UID", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Student" },
                    { 3, "Landlord" },
                    { 4, "University" },
                    { 5, "Consultant" }
                });

            migrationBuilder.InsertData(
                table: "TenancyType",
                columns: new[] { "UID", "Description" },
                values: new object[,]
                {
                    { 1, "Student Bachelor" },
                    { 2, "Student Married Couple" },
                    { 3, "Student UnMarried Couple" },
                    { 4, "Student Married Couple With Children" },
                    { 5, "Student UnMarried Couple With Children" },
                    { 6, "Married Couple" },
                    { 7, "UnMarried Couple" },
                    { 8, "Married Couple With Children" },
                    { 9, "UnMarried Couple With Children" },
                    { 10, "Any" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "UID", "Code", "Continent", "CurrencyUID", "Name" },
                values: new object[,]
                {
                    { 1, "UK", "Europe", 2, "United Kingdom" },
                    { 2, "IND", "Asia", 1, "India" },
                    { 3, "BAN", "Asia", 3, "Bangladesh" },
                    { 4, "SRL", "Asia", 4, "Sri Lanka" },
                    { 5, "PAK", "Asia", 5, "Pakistan" },
                    { 6, "CNA", "Asia", 6, "China" },
                    { 7, "FRA", "Europe", 7, "France" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "UID", "ItemTypeUID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Study Chair" },
                    { 2, 1, "Study Table" },
                    { 3, 1, "Dining Table" },
                    { 4, 1, "Dining Chair" },
                    { 5, 1, "Couch" },
                    { 6, 1, "Bed" },
                    { 7, 1, "Cot" },
                    { 8, 1, "TV Table" },
                    { 9, 1, "Cup Board" },
                    { 10, 2, "Bulb" },
                    { 11, 2, "Electric Kettle" },
                    { 12, 2, "Electric Hob" },
                    { 13, 2, "Electric Oven" },
                    { 14, 2, "Washing Machine" },
                    { 15, 2, "Microwave" },
                    { 16, 3, "Cooker" },
                    { 17, 6, "Boiler" },
                    { 18, 6, "Radiator" },
                    { 19, 5, "Wash Sink" },
                    { 20, 5, "Bath Tub" },
                    { 21, 5, "Closet" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UID", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "LastName", "LastUpdatedBy", "LastUpdatedDate", "Password", "RoleUID", "UserName", "UserType" },
                values: new object[,]
                {
                    { "9135bf6a-0115-4164-a76c-0fa164fb2a44", "9135bf6a-0115-4164-a76c-0fa164fb2a44", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8759), "nora.sde@gmail.com", "Nora", true, "Tom", "9135bf6a-0115-4164-a76c-0fa164fb2a44", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8760), "rege", 3, "nora", 0 },
                    { "97fe4c93-9ba6-486e-8d1e-a2ca2a20c446", "97fe4c93-9ba6-486e-8d1e-a2ca2a20c446", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8667), "nidhin.sde@gmail.com", "Nidhin", true, "Johny", "97fe4c93-9ba6-486e-8d1e-a2ca2a20c446", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8702), "johny", 2, "nidhin", 0 },
                    { "fdb7de88-bed7-4370-b993-c382b3cc574a", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8888), "renjith.sde@gmail.com", "Renjith", true, "M", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8889), "rege", 3, "renjith", 0 }
                });

            migrationBuilder.InsertData(
                table: "Landlord",
                columns: new[] { "UID", "Address", "CountryUID", "CreatedBy", "CreatedDate", "DOB", "IsActive", "LastUpdatedBy", "LastUpdatedDate", "PhoneNumber", "UserUID" },
                values: new object[,]
                {
                    { "30ef617b-f8d2-44b3-88fa-929000313fdd", "46,Lothian Road, Middlesborough", 1, "9135bf6a-0115-4164-a76c-0fa164fb2a44", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8859), new DateTime(1988, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "9135bf6a-0115-4164-a76c-0fa164fb2a44", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8860), "07773636363", "9135bf6a-0115-4164-a76c-0fa164fb2a44" },
                    { "8c04bc83-7c11-46bf-ad3c-11d38ddcbb99", "34,Parliament Road, Middlesborough", 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8900), new DateTime(1994, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8902), "07773636363", "fdb7de88-bed7-4370-b993-c382b3cc574a" }
                });

            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "UID", "Address", "ContactEmail", "ContactNumber", "CountryUID", "IsActive", "Name", "Ratings", "UniversityCode" },
                values: new object[,]
                {
                    { 1, "Tees Valley,Middlesbrough,England", "tees.uni@gmail.com", "7464647464", 1, true, "Teeside University", 3, "UNITEES" },
                    { 2, "Ediburgh,Scotland", "universityofedinburgh.uni@gmail.com", "7334647464", 1, true, "University of Edinburgh", 5, "UNIEDIN" }
                });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "UID", "Address", "CountryUID", "CreatedBy", "CreatedDate", "IsActive", "LandlordUID", "LastUpdatedBy", "LastUpdatedDate", "Name", "PostCode", "Ratings" },
                values: new object[,]
                {
                    { "4f20da6d-9a89-45ad-95fd-f79efec152b3", "Numens Street, Middlesbrough TS3", 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9059), true, "8c04bc83-7c11-46bf-ad3c-11d38ddcbb99", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9060), "House 3", "TS3 2HR", 0f },
                    { "77382e87-4ba7-431f-8044-9711d538354d", "Kings Street, Middlesbrough TS2", 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9007), true, "8c04bc83-7c11-46bf-ad3c-11d38ddcbb99", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9008), "House 2", "TS2 2HR", 0f },
                    { "7af92e80-a6b5-47a4-b54a-bc8280e151bc", "Bennard Street, Middlesbrough TS5", 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9149), true, "8c04bc83-7c11-46bf-ad3c-11d38ddcbb99", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9151), "House 5", "TS5 2HR", 0f },
                    { "a367c899-d1a0-42f2-9316-2380263960d2", "Edward Pease Way, West Park Garden Village, Darlington", 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9104), true, "8c04bc83-7c11-46bf-ad3c-11d38ddcbb99", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9106), "House 4", "DS4 2HR", 0f },
                    { "a37c1f36-4f04-427b-afab-076298bfd704", "Oxford Street, Middlesbrough TS1", 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8919), true, "8c04bc83-7c11-46bf-ad3c-11d38ddcbb99", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8921), "House 1", "TS1 2HR", 0f }
                });

            migrationBuilder.InsertData(
                table: "PropertyAttribute",
                columns: new[] { "UID", "BathroomCount", "BedroomCount", "CreatedBy", "CreatedDate", "FloorCount", "FurnishTypeUID", "IsActive", "IsBackyardAvailable", "IsGarageAvailable", "IsParkingSlotAvailable", "LastUpdatedBy", "LastUpdatedDate", "MaxOccupantCount", "ParkingSlotCount", "PropertyTypeUID", "PropertyUID", "TotalAreaInSqFT" },
                values: new object[,]
                {
                    { "5f154848-6248-4af8-842a-4bd732bb24d8", 3, 6, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9112), 3, 1, true, true, true, true, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9113), 12, 3, 5, "a367c899-d1a0-42f2-9316-2380263960d2", 2600f },
                    { "7140e4ec-fa20-4c51-835e-ec3886e58090", 1, 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9065), 1, 1, true, true, true, true, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9066), 2, 1, 5, "4f20da6d-9a89-45ad-95fd-f79efec152b3", 600f },
                    { "7c61a550-a5b3-4dee-9180-fec3af0eede5", 2, 4, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9155), 2, 1, true, true, true, true, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9156), 8, 2, 5, "7af92e80-a6b5-47a4-b54a-bc8280e151bc", 2000f },
                    { "916ee67e-80e2-4bf7-a339-7736b085a0ea", 2, 4, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8927), 2, 1, true, true, true, true, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8929), 5, 2, 5, "a37c1f36-4f04-427b-afab-076298bfd704", 1200f },
                    { "bac3e894-e15c-4999-83fd-fbc51fb7aaf8", 2, 2, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9017), 1, 1, true, true, true, true, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9018), 3, 1, 5, "77382e87-4ba7-431f-8044-9711d538354d", 700f }
                });

            migrationBuilder.InsertData(
                table: "PropertyListing",
                columns: new[] { "UID", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsCTIAvailableForSale", "LastUpdatedBy", "LastUpdatedDate", "ListedByUser", "ListingAmount", "ListingDate", "PropertyUID" },
                values: new object[,]
                {
                    { "270525d7-20e8-4fbe-9ad9-95a77ac88525", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8944), "4 bed terraced house to rent", true, false, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8945), "fdb7de88-bed7-4370-b993-c382b3cc574a", 2850.0, new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8938), "a37c1f36-4f04-427b-afab-076298bfd704" },
                    { "2b6ce82e-5955-4314-8933-6f3a6a58aaf2", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9024), "2 BHK house to rent", true, false, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9025), "fdb7de88-bed7-4370-b993-c382b3cc574a", 1350.0, new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9022), "77382e87-4ba7-431f-8044-9711d538354d" },
                    { "37b39025-c0d5-4add-b5d7-ac53f59fac49", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9161), "4 bed terraced house to rent", true, false, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9162), "fdb7de88-bed7-4370-b993-c382b3cc574a", 1850.0, new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9159), "7af92e80-a6b5-47a4-b54a-bc8280e151bc" },
                    { "7a402a0d-9a7f-42d8-a2c6-fbaaf001c2dd", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9071), "1 BHK Appartmet to rent", true, false, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9072), "fdb7de88-bed7-4370-b993-c382b3cc574a", 1250.0, new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9069), "4f20da6d-9a89-45ad-95fd-f79efec152b3" },
                    { "f4517879-4cf4-4faa-9c9e-5725d3d83597", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9118), "The Orchard at West Park", true, false, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9119), "fdb7de88-bed7-4370-b993-c382b3cc574a", 2950.0, new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9116), "a367c899-d1a0-42f2-9316-2380263960d2" }
                });

            migrationBuilder.InsertData(
                table: "PropertyListingAttribute",
                columns: new[] { "UID", "AllowedOccupantCount", "AvailableBathroomCount", "AvailableBedroomCount", "AvailableDate", "AvailableParkingSlots", "CreatedBy", "CreatedDate", "IsActive", "IsChildrenAllowed", "IsNew", "IsParkingAvailable", "IsPartyingAllowed", "IsPetsAllowed", "IsSharingAllowed", "IsSmokingAllowed", "IsStudentFriendly", "IsUnisex", "Landmark", "LastUpdatedBy", "LastUpdatedDate", "PropertyAttributeUID", "PropertyListingUID", "TenancyTypeUID" },
                values: new object[,]
                {
                    { "48c035de-5a41-42d8-a431-b373f8dd82a1", 2, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9077), true, true, false, true, true, true, true, true, true, true, "0.5 miles Middlesbrough", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9078), "7140e4ec-fa20-4c51-835e-ec3886e58090", "7a402a0d-9a7f-42d8-a2c6-fbaaf001c2dd", 10 },
                    { "79dbb489-b398-4289-9790-b7cda054aa7f", 12, 3, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9123), true, true, true, true, true, true, true, true, false, true, "0.5 miles Middlesbrough", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9125), "5f154848-6248-4af8-842a-4bd732bb24d8", "f4517879-4cf4-4faa-9c9e-5725d3d83597", 10 },
                    { "8add2f82-5dc3-4a16-9e4f-68cc6e736c3c", 5, 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8953), true, true, true, true, true, true, true, true, true, true, "0.5 miles Middlesbrough", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(8954), "916ee67e-80e2-4bf7-a339-7736b085a0ea", "270525d7-20e8-4fbe-9ad9-95a77ac88525", 10 },
                    { "8fd50323-e236-4cfd-a0f7-a92107feb054", 3, 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9032), true, true, false, true, true, true, true, true, true, true, "0.5 miles Middlesbrough", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9033), "bac3e894-e15c-4999-83fd-fbc51fb7aaf8", "2b6ce82e-5955-4314-8933-6f3a6a58aaf2", 10 },
                    { "a3bbb0c7-0e61-47b7-877d-ee523a76236f", 12, 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9167), true, true, true, true, true, true, true, true, true, true, "0.5 miles Middlesbrough", "fdb7de88-bed7-4370-b993-c382b3cc574a", new DateTime(2023, 1, 9, 22, 57, 53, 199, DateTimeKind.Local).AddTicks(9168), "7c61a550-a5b3-4dee-9180-fec3af0eede5", "37b39025-c0d5-4add-b5d7-ac53f59fac49", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CurrencyUID",
                table: "Country",
                column: "CurrencyUID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemTypeUID",
                table: "Item",
                column: "ItemTypeUID");

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_CountryUID",
                table: "Landlord",
                column: "CountryUID");

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_UserUID",
                table: "Landlord",
                column: "UserUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Property_CountryUID",
                table: "Property",
                column: "CountryUID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_LandlordUID",
                table: "Property",
                column: "LandlordUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAttribute_PropertyTypeUID",
                table: "PropertyAttribute",
                column: "PropertyTypeUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAttribute_PropertyUID",
                table: "PropertyAttribute",
                column: "PropertyUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_FileTypeUID",
                table: "PropertyImage",
                column: "FileTypeUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_ImageTypeUID",
                table: "PropertyImage",
                column: "ImageTypeUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyUID",
                table: "PropertyImage",
                column: "PropertyUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListing_PropertyUID",
                table: "PropertyListing",
                column: "PropertyUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListingAttribute_PropertyAttributeUID",
                table: "PropertyListingAttribute",
                column: "PropertyAttributeUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListingAttribute_PropertyListingUID",
                table: "PropertyListingAttribute",
                column: "PropertyListingUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyListingAttribute_TenancyTypeUID",
                table: "PropertyListingAttribute",
                column: "TenancyTypeUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRenting_PropertyListingUID",
                table: "PropertyRenting",
                column: "PropertyListingUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRenting_TenantUID",
                table: "PropertyRenting",
                column: "TenantUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyReview_PropertyUID",
                table: "PropertyReview",
                column: "PropertyUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyViewing_PropertyListingUID",
                table: "PropertyViewing",
                column: "PropertyListingUID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyViewing_TenantUID",
                table: "PropertyViewing",
                column: "TenantUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfile_TenantUID",
                table: "StudentProfile",
                column: "TenantUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfile_UniversityUID",
                table: "StudentProfile",
                column: "UniversityUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_CountryUID",
                table: "Tenant",
                column: "CountryUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_TenancyTypeUID",
                table: "Tenant",
                column: "TenancyTypeUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_UserUID",
                table: "Tenant",
                column: "UserUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_TenantItem_CurrencyUID",
                table: "TenantItem",
                column: "CurrencyUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_TenantItem_ItemUID",
                table: "TenantItem",
                column: "ItemUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_TenantItem_PropertyRentingUID",
                table: "TenantItem",
                column: "PropertyRentingUID");

            migrationBuilder.CreateIndex(
                name: "IX_TenantPreference_FurnishTypeUID",
                table: "TenantPreference",
                column: "FurnishTypeUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_TenantPreference_PropertyTypeUID",
                table: "TenantPreference",
                column: "PropertyTypeUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_TenantPreference_TenantUID",
                table: "TenantPreference",
                column: "TenantUID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_University_CountryUID",
                table: "University",
                column: "CountryUID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleUID",
                table: "User",
                column: "RoleUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyListingAttribute");

            migrationBuilder.DropTable(
                name: "PropertyReview");

            migrationBuilder.DropTable(
                name: "PropertyViewing");

            migrationBuilder.DropTable(
                name: "StudentProfile");

            migrationBuilder.DropTable(
                name: "TenantItem");

            migrationBuilder.DropTable(
                name: "TenantPreference");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropTable(
                name: "PropertyAttribute");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PropertyRenting");

            migrationBuilder.DropTable(
                name: "FurnishType");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "PropertyListing");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "TenancyType");

            migrationBuilder.DropTable(
                name: "Landlord");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
