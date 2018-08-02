namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public CarService(CarDealerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GerCarsFromMakeFerrari()
        {
            var serializer = new XmlSerializer(typeof(List<FerrariDto>), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/ferrari-cars.xml";

            var ferraries = this.context.Cars
                .Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => this.mapper.Map<FerrariDto>(c))
                .ToList();
            
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, ferraries, namespaces);
            }
        }

        public void GetCarsWithDistance()
        {
            var serializer = new XmlSerializer(typeof(List<CarDto>), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/cars - exported.xml";

            var cars = this.context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => this.mapper.Map<CarDto>(c))
                .ToList();
            
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, cars, namespaces);
            }
        }

        public void GetCarsWithTheirListOfParts()
        {
            var serializer = new XmlSerializer(typeof(List<CarPartsDto>), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/car-parts.xml";

            var carsParts = this.context.Cars.Select(c => new CarPartsDto
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                Parts = c.Parts.Select(p => new PartSupplierDto
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price
                }).ToList()
            }).ToList();
            
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, carsParts, namespaces);
            }
        }
    }
}
