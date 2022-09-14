using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    public partial class SecondMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Departments_TeacherDepartmentId",
                schema: "dbo",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_TeacherDepartmentId",
                schema: "dbo",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "dbo",
                newName: "Department",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                schema: "dbo",
                table: "Department",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                schema: "dbo",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                schema: "dbo",
                newName: "Departments",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                schema: "dbo",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_TeacherDepartmentId",
                schema: "dbo",
                table: "Teacher",
                column: "TeacherDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Departments_TeacherDepartmentId",
                schema: "dbo",
                table: "Teacher",
                column: "TeacherDepartmentId",
                principalSchema: "dbo",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
