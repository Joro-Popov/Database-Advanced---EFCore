namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public SupplierService(CarDealerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void GetLocalSuppliers()
        {
            var serializer = new XmlSerializer(typeof(List<LocalSupplierDto>), new XmlRootAttribute("suppliers"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var path = "../../../XML/local-suppliers.xml";

            var suppliers = this.context.Suppliers
                .Where(s => s.IsImporter == false)
                .ToList();

            var localSuppliers = new List<LocalSupplierDto>();

            foreach (var sup in suppliers)
            {
                var current = this.mapper.Map<LocalSupplierDto>(sup);

                localSuppliers.Add(current);
            }

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, localSuppliers, namespaces);
            }
        }
    }
}
