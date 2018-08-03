namespace ProductShop.Models.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual List<CategoryProduct> Products { get; set; } = new List<CategoryProduct>();
    }
}