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

    public class UserService : IUserService
    {
        private readonly ProductShopDbContext context;
        private readonly IMapper mapper;

        public UserService(ProductShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GetUsersAndProducts()
        {
            var serializer = new XmlSerializer(typeof(UsersDto), new XmlRootAttribute("users"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/users-and-products.xml";

            var users = this.context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .ToList();

            var currentUsers = this.mapper.Map<UsersDto>(users);

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, currentUsers, namespaces);
            }
        }

        public void GetUsersWithSoldProducts()
        {
            var serializer = new XmlSerializer(typeof(List<UserProductsDto>), new XmlRootAttribute("users"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/users-sold-products.xml";

            var users = this.context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToList();

            var userProducts = new List<UserProductsDto>();

            foreach (var user in users)
            {
                var currentUser = this.mapper.Map<UserProductsDto>(user);
                userProducts.Add(currentUser);
            }

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, userProducts, namespaces);
            }
        }
    }
}