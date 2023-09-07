using Microsoft.EntityFrameworkCore.Migrations;

namespace udemy_course_demo.Migrations
{
    public partial class secondupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Salaries",
                newName: "SalaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalaryId",
                table: "Salaries",
                newName: "Id");
        }
    }
}
