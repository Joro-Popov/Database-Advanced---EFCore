using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Type { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public int Age { get; set; }

        [Required]
        public string PassportSerialNumber { get; set; }
        
        [Required]
        public virtual Passport Passport { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
