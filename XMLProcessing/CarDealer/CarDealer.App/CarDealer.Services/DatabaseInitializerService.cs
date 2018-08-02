namespace CarDealer.Services
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models.DomainModels;
    using CarDealer.Models.DTOs;
    using CarDealer.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using DataAnnotations = System.ComponentModel.DataAnnotations;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;
        private readonly Random rndGenerator;

        public DatabaseInitializerService(CarDealerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.rndGenerator = new Random();
        }

        public void InitializeDatabase()
        {
            var isCreated = (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();

            if (!isCreated)
            {
                this.context.Database.Migrate();

                InsertSuppliers();
                InsertParts();
                InsertCars();
                InserCustomers();
                InsertSales();
            }
        }

        private void InserCustomers()
        {
            var path = "../../../XML/customers.xml";
            var serializer = new XmlSerializer(typeof(List<CustomerDto>), new XmlRootAttribute("customers"));

            var deserializedCustomers = (List<CustomerDto>)serializer.Deserialize(new StreamReader(path));

            var customers = new List<Customer>();

            foreach (var cust in deserializedCustomers)
            {
                var current = this.mapper.Map<Customer>(cust);

                if (current.IsYounger)
                {

                }

                customers.Add(current);
            }

            this.context.Customers.AddRange(customers);
            this.context.SaveChanges();
        }

        private void InsertCars()
        {
            var path = "../../../XML/cars.xml";
            var serializer = new XmlSerializer(typeof(List<CarDto>), new XmlRootAttribute("cars"));

            var deserializedCars = (List<CarDto>)serializer.Deserialize(new StreamReader(path));

            var cars = new List<Car>();
            
            foreach (var car in deserializedCars)
            {
                var current = this.mapper.Map<Car>(car);
                cars.Add(current);
            }

            this.context.Cars.AddRange(cars);
            this.context.SaveChanges();

            var carsDb = this.context.Cars.ToList();
            var partCars = this.context.PartCars.ToList();

            foreach (var car in carsDb)
            {
                var count = this.rndGenerator.Next(10, 20);

                for (int index = 0; index < count; index++)
                {
                    var rndpart = this.rndGenerator.Next(1, 130);

                    var containsPart = partCars.Any(p => p.PartId == rndpart && p.CarId == car.Id);

                    if (containsPart)
                    {
                        index--;
                        continue;
                    }

                    partCars.Add(new PartCars { CarId = car.Id, PartId = rndpart });
                }
            }
            this.context.PartCars.AddRange(partCars);
            this.context.SaveChanges();
        }

        private void InsertParts()
        {
            var path = "../../../XML/parts.xml";
            var serializer = new XmlSerializer(typeof(List<PartDto>), new XmlRootAttribute("parts"));

            var deserializedParts = (List<PartDto>)serializer.Deserialize(new StreamReader(path));

            var parts = new List<Part>();
            
            foreach (var part in deserializedParts)
            {
                var supplierId = this.rndGenerator.Next(1, 31);

                var current = this.mapper.Map<Part>(part);
                current.SupplierId = supplierId;

                parts.Add(current);
            }

            this.context.Parts.AddRange(parts);
            this.context.SaveChanges();
        }

        private void InsertSuppliers()
        {
            var path = "../../../XML/suppliers.xml";
            var serializer = new XmlSerializer(typeof(List<SupplierDto>), new XmlRootAttribute("suppliers"));

            var deserializedSuppliers = (List<SupplierDto>)serializer.Deserialize(new StreamReader(path));

            var suppliers = new List<Supplier>();

            foreach (var supplier in deserializedSuppliers)
            {
                var current = this.mapper.Map<Supplier>(supplier);
                suppliers.Add(current);
            }

            this.context.Suppliers.AddRange(suppliers);
            this.context.SaveChanges();
        }

        private void InsertSales()
        {
            var discounts = new decimal[] { 0, 0.5m, 0.10m, 0.15m, 0.20m, 0.30m, 0.40m, 0.50m };

            var sales = new List<Sale>();

            for (int index = 0; index < 40; index++)
            {
                var rndCarId = this.rndGenerator.Next(1, 358);
                var rndCustomerId = this.rndGenerator.Next(1, 30);
                var discountIndex = this.rndGenerator.Next(1, discounts.Length);

                var discount = discounts[discountIndex];
                var customerIsYounger = this.context.Customers.FirstOrDefault(c => c.Id == rndCustomerId).IsYounger;

                if (customerIsYounger)
                {
                    discount += 0.5m;
                }

                var current = new Sale { CarId = rndCarId, CustomerId = rndCustomerId, Discount = discount };

                sales.Add(current);
            }

            this.context.Sales.AddRange(sales);
            this.context.SaveChanges();
        }
    }
}
