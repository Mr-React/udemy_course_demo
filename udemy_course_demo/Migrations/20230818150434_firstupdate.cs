using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace udemy_course_demo.Migrations
{
    public partial class firstupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaryId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetails_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SalaryId",
                table: "Persons",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetails_PersonId",
                table: "PersonDetails",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Salaries_SalaryId",
                table: "Persons",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Salaries_SalaryId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "PersonDetails");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Persons_SalaryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "Persons");
        }
    }
}
