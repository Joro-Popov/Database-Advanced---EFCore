namespace P01_BillsPaymentSystem.Data.Models
{
    using P01_BillsPaymentSystem.Data.Models.Attributes;
    using P01_BillsPaymentSystem.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public PaymentType Type { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}