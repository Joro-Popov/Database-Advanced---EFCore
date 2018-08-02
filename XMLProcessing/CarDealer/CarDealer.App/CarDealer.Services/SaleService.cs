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
            var serializer = new XmlSerializer(typeof(List<SaleDto>), new XmlRootAttribute("sales"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/sales-discounts.xml";

            var sales = this.context.Sales.ToList();

            var saleDtos = new List<SaleDto>();

            foreach (var sale in sales)
            {
                var current = this.mapper.Map<SaleDto>(sale);
                saleDtos.Add(current);
            }

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, saleDtos, namespaces);
            }
        }
    }
}
