namespace ProductShop.Models.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual List<Product> ProductsSold { get; set; } = new List<Product>();

        public virtual List<Product> ProductsBought { get; set; } = new List<Product>();

        public virtual List<UserFriends> UserFriends { get; set; } = new List<UserFriends>();
    }
}