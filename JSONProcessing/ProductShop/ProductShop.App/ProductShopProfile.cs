namespace ProductShop.App.Mappings
{
    using AutoMapper;
    using ProductShop.Models.DomainModels;
    using ProductShop.Models.DTOs;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            
            CreateMap<Product, ProductDto>().ReverseMap();
            
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}