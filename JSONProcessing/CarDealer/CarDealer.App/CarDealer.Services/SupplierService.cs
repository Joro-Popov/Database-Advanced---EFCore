namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

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
            var suppliers = this.context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var path = "../../../JSON/local-suppliers";
            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            File.WriteAllText(path, json);
        }
    }
}