namespace ProductShop.Services
{
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models.DTOs;
    using ProductShop.Services.Contracts;
    using System.IO;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly ProductShopDbContext context;

        public ProductService(ProductShopDbContext context)
        {
            this.context = context;
        }

        public void GetProductsInRange()
        {
            var products = this.context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerName = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var deserializedProduct = JsonConvert.SerializeObject(products, Formatting.Indented);
            var path = "../../../JSON/products-in-range.json";

            File.WriteAllText(path, deserializedProduct);
        }
    }
}