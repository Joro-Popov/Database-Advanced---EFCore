namespace CarDealer.App
{
    using AutoMapper;
    using CarDealer.Models.DomainModels;
    using CarDealer.Models.DTOs;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<Part, PartDto>().ReverseMap();

            CreateMap<Car, CarDto>().ReverseMap();

            CreateMap<Car, FerrariDto>().ReverseMap();
            
            CreateMap<Car, SaleCarDto>();

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Customer, CustomerSaleDto>()
                .ForMember(dto => dto.BoughtCars,
                           opt => opt.MapFrom(src => src.Boughts.Count))
                .ForMember(dto => dto.SpentMoney,
                           opt => opt.MapFrom(src => src.Boughts.Sum(s => s.Car.Parts.Sum(x => x.Part.Price))));

            CreateMap<Supplier, LocalSupplierDto>()
                .ForMember(dto => dto.PartsCount,
                           opt => opt.MapFrom(src => src.Parts.Count));
            
            CreateMap<PartCars, PartSupplierDto>()
                .ForMember(dto => dto.Name,
                           opt => opt.MapFrom(src => src.Part.Name))
                .ForMember(dto => dto.Price,
                           opt => opt.MapFrom(src => src.Part.Price));

            CreateMap<Sale, SaleDto>()
                .ForMember(dto => dto.Car,
                           opt => opt.MapFrom(src => src.Car))
                .ForMember(dto => dto.CustomerName,
                           opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dto => dto.Price,
                           opt => opt.MapFrom(src => src.Car.Parts.Sum(p => p.Part.Price)));
        }
    }
}
