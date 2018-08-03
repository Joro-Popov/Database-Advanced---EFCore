namespace ProductShop.Models.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? BuyerId { get; set; }
        public virtual User Buyer { get; set; }

        public int SellerId { get; set; }
        public virtual User Seller { get; set; }

        public virtual List<CategoryProduct> Categories { get; set; } = new List<CategoryProduct>();
    }
}