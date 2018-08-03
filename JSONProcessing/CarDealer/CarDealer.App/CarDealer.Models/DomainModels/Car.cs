namespace CarDealer.Models.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Make { get; set; }

        [Required]
        [MinLength(3)]
        public string Model { get; set; }

        public ulong TravelledDistance { get; set; }

        public virtual ICollection<PartCars> Parts { get; set; } = new List<PartCars>();

        public virtual ICollection<Sale> Sales { get; set; }
    }
}