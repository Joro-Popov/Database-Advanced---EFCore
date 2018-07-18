namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Globalization;
    using System.Text;

    public class CreditCard
    {
        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expirationDate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreditCardId { get; set; }

        [Required]
        public decimal Limit { get; private set; }

        [Required]
        public decimal MoneyOwed { get; private set; }

        [NotMapped]
        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        [Required]
        public DateTime ExpirationDate { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal ammount)
        {
            if (this.MoneyOwed < ammount)
            {
                throw new ArgumentException(ErrorMessages.insufficientFunds);
            }

            if (ammount <= 0)
            {
                throw new ArgumentException(ErrorMessages.negativeAmmount);
            }
            this.MoneyOwed -= ammount;
        }

        public void Deposit(decimal ammount)
        {
            if (ammount <= 0)
            {
                throw new ArgumentException(ErrorMessages.negativeAmmount);
            }

            this.MoneyOwed += ammount;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"-- ID: {this.CreditCardId}");
            builder.AppendLine($"--- Limit: {this.Limit:f2}");
            builder.AppendLine($"--- Money Owed: {this.MoneyOwed:f2}");
            builder.AppendLine($"--- Limit Left: {this.LimitLeft:f2}");
            builder.AppendLine($"--- Expiration Date: {this.ExpirationDate.ToString("yyy/MM", CultureInfo.InvariantCulture)}");

            return builder.ToString().Trim();
        }
    }
}