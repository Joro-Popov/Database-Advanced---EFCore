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

            CreateMap<List<User>, UsersDto>()
                .ForMember(dto => dto.Count,
                           opt => opt.MapFrom(src => src.Count()))
                .ForMember(dto => dto.Users,
                           opt => opt.MapFrom(src => src));

            CreateMap<User, UserProductsDto>()
                .ForMember(dto => dto.Products,
                           opt => opt.MapFrom(src => src.ProductsSold));

            CreateMap<User, UsersAndProductsDto>()
                .ForMember(dto => dto.SoldProduct,
                           opt => opt.MapFrom(src => src.ProductsSold));

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductRangeDto>()
                .ForMember(dto => dto.BuyerName,
                           opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName));

            CreateMap<Product, ProductUserDto>();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<List<Product>, SoldProductsDto>()
                .ForMember(dto => dto.Products,
                           opt => opt.MapFrom(src => src))
                .ForMember(dto => dto.Count,
                           opt => opt.MapFrom(src => src.Count));

            CreateMap<Category, CategoryProductDto>()
                .ForMember(dto => dto.NumberOfProducts,
                           opt => opt.MapFrom(src => src.Products.Count))
                .ForMember(dto => dto.TotalRevenue,
                           opt => opt.MapFrom(src => src.Products.Sum(p => p.Product.Price)))
                .ForMember(dto => dto.AveragePrice,
                           opt => opt.MapFrom(src => src.Products.Select(s => s.Product.Price).DefaultIfEmpty(0).Average()));
        }
    }
}