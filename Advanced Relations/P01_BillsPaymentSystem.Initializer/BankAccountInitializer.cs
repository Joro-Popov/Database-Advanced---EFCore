namespace P01_BillsPaymentSystem.Initializer
{
    using P01_BillsPaymentSystem.Data.Models;
    using System.Collections.Generic;

    public class BankAccountInitializer
    {
        public static List<BankAccount> GetBankAccounts()
        {
            var bankAccounts = new List<BankAccount>()
            {
                new BankAccount(2000.00m, "PostBank", "PBNKBG22"),
                new BankAccount(740.00m, "Societe Generale Express Bank", "SGEBBG30"),
                new BankAccount(4500.00m, "First Investment Bank", "FIBKBG11"),
                new BankAccount(1000.00m, "United Bulgarian Bank", "UBBBG44"),
                new BankAccount(5500.00m, "Raifeissen Bank", "RFBBG12")
            };

            return bankAccounts;
        }
    }
}