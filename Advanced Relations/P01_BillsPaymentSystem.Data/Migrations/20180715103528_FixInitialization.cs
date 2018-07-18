using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_BillsPaymentSystem.Data.Migrations
{
    public partial class FixInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_BankAccounts_BankAccountId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_CreditCards_CreditCardId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_BankAccountId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_CreditCardId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_UserId",
                table: "PaymentMethods");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "SWIFTCode",
                table: "BankAccounts",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_UserId_BankAccountId_CreditCardId",
                table: "PaymentMethods",
                columns: new[] { "UserId", "BankAccountId", "CreditCardId" },
                unique: true,
                filter: "[BankAccountId] IS NOT NULL AND [CreditCardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_PaymentMethods_BankAccountId",
                table: "BankAccounts",
                column: "BankAccountId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_PaymentMethods_CreditCardId",
                table: "CreditCards",
                column: "CreditCardId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_PaymentMethods_BankAccountId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_PaymentMethods_CreditCardId",
                table: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_UserId_BankAccountId_CreditCardId",
                table: "PaymentMethods");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                unicode: false,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "SWIFTCode",
                table: "BankAccounts",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BankAccountId",
                table: "PaymentMethods",
                column: "BankAccountId",
                unique: true,
                filter: "[BankAccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CreditCardId",
                table: "PaymentMethods",
                column: "CreditCardId",
                unique: true,
                filter: "[CreditCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_UserId",
                table: "PaymentMethods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_BankAccounts_BankAccountId",
                table: "PaymentMethods",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_CreditCards_CreditCardId",
                table: "PaymentMethods",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "CreditCardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}