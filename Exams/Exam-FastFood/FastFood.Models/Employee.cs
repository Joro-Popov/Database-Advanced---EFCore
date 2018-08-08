namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(15, 80)]
        [Required]
        public int Age { get; set; }

        public int PositionId { get; set; }

        [Required]
        public virtual Position Position { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}