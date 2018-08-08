namespace PetClinic.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Passport
    {
        [Key]
        [RegularExpression("^[A-z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }

        [Required]
        public virtual Animal Animal { get; set; }
        
        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        [Required]
        public string OwnerPhoneNumber { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string OwnerName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
