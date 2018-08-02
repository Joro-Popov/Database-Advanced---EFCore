namespace ProductShop.Services
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Models.DTOs;
    using ProductShop.Services.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class ProductService : IProductService
    {
        private readonly ProductShopDbContext context;
        private readonly IMapper mapper;

        public ProductService(ProductShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GetProductsInRange()
        {
            var serializer = new XmlSerializer(typeof(List<ProductRangeDto>), new XmlRootAttribute("products"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/products-in-range.xml";

            var products = this.context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                .OrderBy(p => p.Price)
                .ToArray();

            var productDTOs = new List<ProductRangeDto>();

            foreach (var prod in products)
            {
                var current = this.mapper.Map<ProductRangeDto>(prod);
                productDTOs.Add(current);
            }

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, productDTOs, namespaces);
            }
        }
    }
}