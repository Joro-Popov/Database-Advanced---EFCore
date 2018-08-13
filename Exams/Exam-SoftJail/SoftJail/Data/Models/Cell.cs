namespace SoftJail.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cell
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 1000)]
        [Required]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
        
        public int DepartmentId { get; set; }

        [Required]
        public virtual Department Department { get; set; }

        public virtual ICollection<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
    }
}
