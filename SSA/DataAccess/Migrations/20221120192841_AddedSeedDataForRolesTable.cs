using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddedSeedDataForRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "UID", "Name" },
                values: new object[,]
                {
                    { "6e9d2477-d595-429f-8e88-e0180dab3123", "University" },
                    { "704dcef7-4174-4920-be62-dde16d5d7d8f", "Admin" },
                    { "be026808-1b1d-4d8f-a5eb-bdcaefe5760c", "Consultant" },
                    { "cdcdd48b-e287-4e53-9730-00ddb49aafc7", "Landlord" },
                    { "dd2634b3-6842-4c72-b85f-71213ad07075", "Student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "UID",
                keyValue: "6e9d2477-d595-429f-8e88-e0180dab3123");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "UID",
                keyValue: "704dcef7-4174-4920-be62-dde16d5d7d8f");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "UID",
                keyValue: "be026808-1b1d-4d8f-a5eb-bdcaefe5760c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "UID",
                keyValue: "cdcdd48b-e287-4e53-9730-00ddb49aafc7");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "UID",
                keyValue: "dd2634b3-6842-4c72-b85f-71213ad07075");
        }
    }
}
