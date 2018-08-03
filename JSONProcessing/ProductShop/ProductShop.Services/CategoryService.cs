namespace ProductShop.Services
{
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models.DTOs;
    using ProductShop.Services.Contracts;
    using System.IO;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly ProductShopDbContext context;

        public CategoryService(ProductShopDbContext context)
        {
            this.context = context;
        }

        public void GetCategories()
        {
            var categories = this.context.Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => new CategoryProductDto
                {
                    Name = c.Name,
                    NumberOfProducts = c.Products.Count,
                    AveragePrice = c.Products.Select(s => s.Product.Price).DefaultIfEmpty(0).Average(),
                    TotalRevenue = c.Products.Sum(p => p.Product.Price)
                })
                .ToList();

            var path = "../../../JSON/categories-by-products.json";
            var jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText(path, jsonCategories);
        }
    }
}