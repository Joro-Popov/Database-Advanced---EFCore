namespace CarDealer.Models.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PartCars> Cars { get; set; } = new List<PartCars>();
    }
}
