namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vet
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Profession { get; set; }

        [Range(22,65)]
        [Required]
        public int Age { get; set; }

        [RegularExpression(@"^(\+359|0)[0-9]{9}")]
        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
