namespace Employees.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId1",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId1",
                table: "Employees",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeId1",
                table: "Employees",
                newName: "IX_Employees_ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Employees",
                newName: "EmployeeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                newName: "IX_Employees_EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId1",
                table: "Employees",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}