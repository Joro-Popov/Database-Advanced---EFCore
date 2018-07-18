namespace P01_BillsPaymentSystem
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Initializer;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {
                    context.Database.Migrate();
                    Initialize.Seed(context);
                }

                Console.WriteLine("Please enter User Id:");

                var userId = int.Parse(Console.ReadLine());

                try
                {
                    PrintUser(context, userId);

                    Console.WriteLine("Do you want to make a payment? Y/N");
                    var answer = Console.ReadLine().ToLower();

                    if (answer == "y")
                    {
                        Console.WriteLine("Please enter amount:");

                        decimal amount = decimal.Parse(Console.ReadLine());

                        PayBills(userId, amount, context);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintUser(BillsPaymentSystemContext contex, int userId)
        {
            var user = contex.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.userDoesNotExist, userId));
            }

            Console.WriteLine(user);
        }

        private static void PayBills(int userId, decimal ammount, BillsPaymentSystemContext context)
        {
            using (context)
            {
                var userBankAccounts = context.Users
                    .FirstOrDefault(u => u.UserId == userId)
                    .PaymentMethods
                    .Select(b => b.BankAccount)
                    .Where(ba => ba != null)
                    .OrderBy(pm => pm.BankAccountId);

                var userCreditCards = context.Users
                    .FirstOrDefault(u => u.UserId == userId)
                    .PaymentMethods
                    .Select(c => c.CreditCard)
                    .Where(cc => cc != null)
                    .OrderBy(pm => pm.CreditCardId);

                foreach (var ba in userBankAccounts)
                {
                    ba.Withdraw(ammount);
                }

                foreach (var cc in userCreditCards)
                {
                    cc.Withdraw(ammount);
                }

                context.SaveChanges();
            }
        }
    }
}