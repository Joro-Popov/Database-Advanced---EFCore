namespace CarDealer.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public bool IsYounger => (DateTime.Now.Year - BirthDate.Year) < 2;

        public virtual ICollection<Sale> Boughts { get; set; }
    }
}
