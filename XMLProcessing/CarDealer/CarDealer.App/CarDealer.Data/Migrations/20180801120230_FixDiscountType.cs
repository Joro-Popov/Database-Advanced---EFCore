using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Data.Migrations
{
    public partial class FixDiscountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Sales",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Sales",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldDefaultValueSql: "0");
        }
    }
}
