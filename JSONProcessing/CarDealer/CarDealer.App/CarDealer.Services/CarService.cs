namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public CarService(CarDealerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GerCarsFromMakeToyota()
        {
            var toyotaCars = this.context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ToyotaDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var path = @"../../../JSON/toyota-cars.json";
            var Json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            File.WriteAllText(path, Json);
        }

        public void GetCarsWithDistance()
        {
            var cars = this.context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => this.mapper.Map<CarDto>(c))
                .ToList();
        }

        public void GetCarsWithTheirListOfParts()
        {
            var carsParts = this.context.Cars
                .Select(c => new CarListPartsDto
                {
                    Car = new CarsDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.Parts.Select(p => new PartSupplierDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    }).ToList()
                });

            var path = @"../../../JSON/cars-and-parts.json";
            var json = JsonConvert.SerializeObject(carsParts, Formatting.Indented);

            File.WriteAllText(path, json);
        }
    }
}