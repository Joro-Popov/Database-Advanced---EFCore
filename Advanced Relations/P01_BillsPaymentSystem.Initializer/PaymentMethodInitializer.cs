namespace P01_BillsPaymentSystem.Initializer
{
    using P01_BillsPaymentSystem.Data.Models;
    using System.Collections.Generic;

    public class PaymentMethodInitializer
    {
        public static List<PaymentMethod> GetPaymentMethods()
        {
            var paymentMethods = new List<PaymentMethod>()
            {
                new PaymentMethod{ Type = Data.Models.Enums.PaymentType.BankAccount, UserId = 1, BankAccountId = 4},
                new PaymentMethod{ Type = Data.Models.Enums.PaymentType.CreditCard, UserId = 2, CreditCardId = 1},
                new PaymentMethod{ Type = Data.Models.Enums.PaymentType.CreditCard, UserId = 3, CreditCardId = 3},
                new PaymentMethod{ Type = Data.Models.Enums.PaymentType.BankAccount, UserId = 4, BankAccountId = 2},
                new PaymentMethod{ Type = Data.Models.Enums.PaymentType.CreditCard, UserId = 1, CreditCardId = 2},
                new PaymentMethod{ Type = Data.Models.Enums.PaymentType.BankAccount, UserId = 5, BankAccountId = 5}
            };

            return paymentMethods;
        }
    }
}