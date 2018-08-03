namespace ProductShop.Services
{
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models.DTOs;
    using ProductShop.Services.Contracts;
    using System.IO;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly ProductShopDbContext context;

        public UserService(ProductShopDbContext context)
        {
            this.context = context;
        }

        public void GetUsersAndProducts()
        {
            var usersDto = new UsersDto
            {
                Count = this.context.Users.Count(),
                Users = this.context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UsersAndProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProduct = new SoldProductsDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold.Select(p => new ProductUserDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).ToList()
                    }
                }).ToList()
            };
            

            var path = "../../../JSON/users-and-products.json";
            var jsonUsers = JsonConvert.SerializeObject(usersDto, Formatting.Indented);

            File.WriteAllText(path, jsonUsers);
        }

        public void GetUsersWithSoldProducts()
        {
            var users = this.context.Users
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Select(p => p.BuyerId) != null)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(p => new ProductDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    }).ToList()
                })
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(users, Formatting.Indented);
            var path = "../../../JSON/users-sold-products.json";

            File.WriteAllText(path, jsonProducts);
        }
    }
}