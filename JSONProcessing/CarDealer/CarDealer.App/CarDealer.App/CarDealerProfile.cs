namespace CarDealer.App
{
    using AutoMapper;
    using CarDealer.Models.DomainModels;
    using CarDealer.Models.DTOs;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<Part, PartDto>().ReverseMap();

            CreateMap<Car, CarDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}