namespace P01_BillsPaymentSystem.Data.Models
{
    using P01_BillsPaymentSystem.Data.Models.Attributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class User
    {
        public User()
        {
            this.PaymentMethods = new List<PaymentMethod>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(80)]
        [NonUnicode]
        public string Email { get; set; }

        [Required]
        [MaxLength(25)]
        [NonUnicode]
        public string Password { get; set; }

        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            var bankAccounts = this.PaymentMethods
                .Select(ba => ba.BankAccount)
                .Where(ba => ba != null)
                .ToList();

            var creditCards = this.PaymentMethods
                .Select(c => c.CreditCard)
                .Where(cc => cc != null)
                .ToList();

            builder.AppendLine($"User: {this.FirstName} {this.LastName}");
            builder.AppendLine("Bank Accounts:");

            if (!bankAccounts.Any())
            {
                builder.AppendLine("(No bank accounts!)");
            }
            else
            {
                foreach (var ba in bankAccounts)
                {
                    builder.AppendLine(ba.ToString());
                }
            }

            builder.AppendLine("Credit Cards:");

            if (!creditCards.Any())
            {
                builder.AppendLine("(No credit cards!)");
            }
            else
            {
                foreach (var cc in creditCards)
                {
                    builder.AppendLine(cc.ToString());
                }
            }

            return builder.ToString().Trim();
        }
    }
}