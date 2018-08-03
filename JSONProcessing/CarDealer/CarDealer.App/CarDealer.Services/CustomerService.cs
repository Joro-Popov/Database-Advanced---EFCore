namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public CustomerService(CarDealerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GetTotalSalesByCustomer()
        {
            var customers = this.context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new CustomerSaleDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(x => x.Car.Parts.Sum(p => p.Part.Price))
                })
                .ToList();

            var path = @"../../../JSON/customers-total-sales";
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText(path, json);
        }

        public void GetOrderedCustomers()
        {
            var customers = this.context.Customers
                .OrderBy(c => c.BirthDate)
                .Select(c => new OrderedCustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYounger = c.IsYounger,
                    Sales = c.Sales.Take(0).ToList()
                })
                .ToList();

            var jsonString = JsonConvert.SerializeObject(customers, Formatting.Indented);

            var path = @"../../../JSON/ordered-customers.json";

            File.WriteAllText(path, jsonString);
        }
    }
}