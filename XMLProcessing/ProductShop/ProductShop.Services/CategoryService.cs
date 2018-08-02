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

    public class CategoryService : ICategoryService
    {
        private readonly ProductShopDbContext context;
        private readonly IMapper mapper;

        public CategoryService(ProductShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GetCategories()
        {
            var serializer = new XmlSerializer(typeof(List<CategoryProductDto>), new XmlRootAttribute("categories"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/categories-by-products.xml";

            var categories = this.context.Categories
                .OrderByDescending(c => c.Products.Count)
                .ToList();

            var categoryProducts = new List<CategoryProductDto>();

            foreach (var category in categories)
            {
                var current = this.mapper.Map<CategoryProductDto>(category);
                categoryProducts.Add(current);
            }

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, categoryProducts, namespaces);
            }
        }
    }
}