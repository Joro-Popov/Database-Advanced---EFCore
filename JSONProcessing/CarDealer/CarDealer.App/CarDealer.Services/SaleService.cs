namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public SaleService(CarDealerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GetSalesWithDiscount()
        {
            var sales = this.context.Sales
                .Select(s => new SaleDiscountDto
                {
                    Car = new CarsDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(p => p.Part.Price),
                })
                .ToList();

            var path = @"../../../JSON/sale-discounts.json";
            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            File.WriteAllText(path, json);
        }
    }
}