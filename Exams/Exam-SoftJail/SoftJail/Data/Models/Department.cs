namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Cell> Cells { get; set; } = new List<Cell>();

        public virtual ICollection<Officer> Officers { get; set; } = new List<Officer>();
    }
}
