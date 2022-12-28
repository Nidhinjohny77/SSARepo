using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CorrectedTenantschemacolumnnametypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_TenancyType_TenantTypeUID",
                table: "Tenant");

            migrationBuilder.RenameColumn(
                name: "TenantTypeUID",
                table: "Tenant",
                newName: "TenancyTypeUID");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_TenantTypeUID",
                table: "Tenant",
                newName: "IX_Tenant_TenancyTypeUID");

            migrationBuilder.UpdateData(
                table: "University",
                keyColumn: "UID",
                keyValue: 1,
                columns: new[] { "IsActive", "Ratings" },
                values: new object[] { true, 3 });

            migrationBuilder.UpdateData(
                table: "University",
                keyColumn: "UID",
                keyValue: 2,
                columns: new[] { "IsActive", "Ratings" },
                values: new object[] { true, 5 });

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_TenancyType_TenancyTypeUID",
                table: "Tenant",
                column: "TenancyTypeUID",
                principalTable: "TenancyType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_TenancyType_TenancyTypeUID",
                table: "Tenant");

            migrationBuilder.RenameColumn(
                name: "TenancyTypeUID",
                table: "Tenant",
                newName: "TenantTypeUID");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_TenancyTypeUID",
                table: "Tenant",
                newName: "IX_Tenant_TenantTypeUID");

            migrationBuilder.UpdateData(
                table: "University",
                keyColumn: "UID",
                keyValue: 1,
                columns: new[] { "IsActive", "Ratings" },
                values: new object[] { false, 0 });

            migrationBuilder.UpdateData(
                table: "University",
                keyColumn: "UID",
                keyValue: 2,
                columns: new[] { "IsActive", "Ratings" },
                values: new object[] { false, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_TenancyType_TenantTypeUID",
                table: "Tenant",
                column: "TenantTypeUID",
                principalTable: "TenancyType",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
