namespace P01_BillsPaymentSystem.Data.Models
{
    using P01_BillsPaymentSystem.Data.Models.Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class BankAccount
    {
        public BankAccount()
        {
        }

        public BankAccount(decimal balance, string bankName, string swiftCode)
            : this()
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SWIFTCode = swiftCode;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        [Required]
        public decimal Balance { get; private set; }

        [Required]
        [MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(20)]
        [NonUnicode]
        public string SWIFTCode { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal ammount)
        {
            if (this.Balance < ammount)
            {
                throw new ArgumentException(ErrorMessages.insufficientFunds);
            }

            if (ammount <= 0)
            {
                throw new ArgumentException(ErrorMessages.negativeAmmount);
            }

            this.Balance -= ammount;
        }

        public void Deposit(decimal ammount)
        {
            if (ammount <= 0)
            {
                throw new ArgumentException(ErrorMessages.negativeAmmount);
            }

            this.Balance += ammount;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"-- ID: {this.BankAccountId}");
            builder.AppendLine($"--- Balance: {this.Balance:f2}");
            builder.AppendLine($"--- Bank: {this.BankName}");
            builder.AppendLine($"--- SWIFT: {this.SWIFTCode}");

            return builder.ToString().Trim();
        }
    }
}