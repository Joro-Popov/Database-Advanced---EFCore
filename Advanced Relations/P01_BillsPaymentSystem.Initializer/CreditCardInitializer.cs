namespace P01_BillsPaymentSystem.Initializer
{
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;

    public class CreditCardInitializer
    {
        public static List<CreditCard> GetCreditCards()
        {
            var creditCards = new List<CreditCard>()
            {
                new CreditCard(5000.00m, 2000.00m, new DateTime(2020, 01, 01)),
                new CreditCard(20000.00m, 4500.00m, new DateTime(2022, 03, 01)),
                new CreditCard(5000000.00m, 100000.00m, new DateTime(2019, 12, 01)),
                new CreditCard(10000.00m, 800.00m, new DateTime(2021, 08, 01))
            };

            return creditCards;
        }
    }
}