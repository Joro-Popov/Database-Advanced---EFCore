namespace ProductShop.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using ProductShop.Data;
    using ProductShop.Models.DomainModels;
    using ProductShop.Models.DTOs;
    using ProductShop.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using DataAnnotations = System.ComponentModel.DataAnnotations;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private ProductShopDbContext context;
        private IMapper mapper;
        private Random rndGenerator;

        public DatabaseInitializerService(ProductShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.rndGenerator = new Random();
        }

        public void InitializeDatabase()
        {
            var isCreated = (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();

            if (!isCreated)
            {
                this.context.Database.Migrate();

                InsertUsers();
                InsertProducts();
                InsertCategories();
                InsertProductCategories();
            }
        }

        private void InsertUsers()
        {
            var path = "../../../XML/users.xml";
            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));

            var deserializedUsers = (UserDto[])serializer.Deserialize(new StreamReader(path));

            var users = new List<User>();

            foreach (var user in deserializedUsers)
            {
                if (!IsValid(user))
                {
                    continue;
                }

                var currentUser = mapper.Map<User>(user);
                users.Add(currentUser);
            }

            this.context.Users.AddRange(users);
            this.context.SaveChanges();
        }

        private void InsertProducts()
        {
            var path = "../../../XML/products.xml";
            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));

            var deserializedProducts = (ProductDto[])serializer.Deserialize(new StreamReader(path));

            var products = new List<Product>();

            for (int index = 0; index < deserializedProducts.Length; index++)
            {
                var currentProductDto = deserializedProducts[index];

                if (!IsValid(currentProductDto))
                {
                    continue;
                }
                var buyerId = rndGenerator.Next(1, 30);
                var sellerId = rndGenerator.Next(31, 56);

                var currentProduct = mapper.Map<Product>(currentProductDto);

                currentProduct.SellerId = sellerId;
                currentProduct.BuyerId = buyerId;

                if (index % 5 == 0)
                {
                    currentProduct.BuyerId = null;
                }

                products.Add(currentProduct);
            }

            this.context.Products.AddRange(products);
            this.context.SaveChanges();
        }

        private void InsertCategories()
        {
            var path = "../../../XML/categories.xml";
            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));

            var deserializedCategories = (CategoryDto[])serializer.Deserialize(new StreamReader(path));

            var categories = new List<Category>();

            foreach (var category in deserializedCategories)
            {
                if (!IsValid(category))
                {
                    continue;
                }

                var currentCategory = mapper.Map<Category>(category);
                categories.Add(currentCategory);
            }

            this.context.Categories.AddRange(categories);
            this.context.SaveChanges();
        }

        private void InsertProductCategories()
        {
            var categories = context.Categories.ToList();

            var products = context.Products.ToList();

            var categoryProducts = new List<CategoryProduct>();

            for (int index = 0; index < products.Count; index++)
            {
                var rndCategory = rndGenerator.Next(1, categories.Count());
                var rndProduct = products[index];

                var current = new CategoryProduct { Category = categories[rndCategory], Product = rndProduct };

                categoryProducts.Add(current);
            }

            this.context.CategoryProducts.AddRange(categoryProducts);
            this.context.SaveChanges();
        }

        private bool IsValid(object obj)
        {
            var validationContext = new DataAnnotations.ValidationContext(obj);
            var validationResults = new List<DataAnnotations.ValidationResult>();

            return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}