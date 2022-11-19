using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedTableNamesToSingularVerb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_UniversityUID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserUID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleUID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "University");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleUID",
                table: "User",
                newName: "IX_User_RoleUID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UserUID",
                table: "Student",
                newName: "IX_Student_UserUID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UniversityUID",
                table: "Student",
                newName: "IX_Student_UniversityUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_University",
                table: "University",
                column: "UID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ProfileUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_University_UniversityUID",
                table: "Student",
                column: "UniversityUID",
                principalTable: "University",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserUID",
                table: "Student",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleUID",
                table: "User",
                column: "RoleUID",
                principalTable: "Role",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_University_UniversityUID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserUID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleUID",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_University",
                table: "University");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "University",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleUID",
                table: "Users",
                newName: "IX_Users_RoleUID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_UserUID",
                table: "Students",
                newName: "IX_Students_UserUID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_UniversityUID",
                table: "Students",
                newName: "IX_Students_UniversityUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "UID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ProfileUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_UniversityUID",
                table: "Students",
                column: "UniversityUID",
                principalTable: "Universities",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserUID",
                table: "Students",
                column: "UserUID",
                principalTable: "Users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleUID",
                table: "Users",
                column: "RoleUID",
                principalTable: "Roles",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
