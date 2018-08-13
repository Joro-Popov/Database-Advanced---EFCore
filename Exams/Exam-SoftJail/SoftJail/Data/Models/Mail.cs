namespace SoftJail.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"^[\w\d\s]+str\.$")]
        [Required]
        public string Address { get; set; }
        
        public int PrisonerId { get; set; }

        [Required]
        public virtual Prisoner Prisoner { get; set; }
    }
}
