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
            var serializer = new XmlSerializer(typeof(List<CustomerSaleDto>), new XmlRootAttribute("customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/customers-total-sales.xml";

            var cutomers = this.context.Customers
                .Where(c => c.Boughts.Count >= 1)
                .ToList();

            var customerDtos = new List<CustomerSaleDto>();

            foreach (var customer in cutomers)
            {
                var current = this.mapper.Map<CustomerSaleDto>(customer);

                customerDtos.Add(current);
            }

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, customerDtos, namespaces);
            }
        }
    }
}
