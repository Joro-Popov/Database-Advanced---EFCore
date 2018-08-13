using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        public int PrisonerId { get; set; }
        [Required]
        public virtual Prisoner Prisoner { get; set; }
        
        public int OfficerId { get; set; }
        [Required]
        public virtual Officer Officer { get; set; }
    }
}
