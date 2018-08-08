using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var deserializedEmployees = JsonConvert.DeserializeObject<List<EmployeeDto>>(jsonString);

            var employees = new List<Employee>();

            foreach (var emp in deserializedEmployees)
            {
                if (!IsValid(emp))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var positionExists = context.Positions.Any(p => p.Name == emp.Position);

                if (!positionExists)
                {
                    var position = new Position { Name = emp.Position };
                    
                    context.Positions.Add(position);
                    context.SaveChanges();
                }

                var current = new Employee
                {
                    Name = emp.Name,
                    Age = emp.Age,
                    Position = context.Positions.FirstOrDefault(p => p.Name == emp.Position),
                };
                
                employees.Add(current);

                sb.AppendLine(string.Format(SuccessMessage, emp.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var deserializedItems = JsonConvert.DeserializeObject<List<ItemDto>>(jsonString);

            var Items = new List<Item>();

            foreach (var item in deserializedItems)
            {
                if (!IsValid(item) || Items.Any(i => i.Name == item.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var categoryExists = context.Categories.Any(c => c.Name == item.Category);

                if (!categoryExists)
                {
                    var category = new Category { Name = item.Category };

                    context.Categories.Add(category);
                    context.SaveChanges();
                }

                var current = new Item
                {
                    Name = item.Name,
                    Category = context.Categories.FirstOrDefault(c => c.Name == item.Category),
                    Price = item.Price
                };

                Items.Add(current);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(Items);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(List<OrderDto>), new XmlRootAttribute("Orders"));

            var deserializedOrders = (List<OrderDto>)serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var orders = new List<Order>();

            foreach (var order in deserializedOrders)
            {
                var employeeExists = context.Employees.Any(e => e.Name == order.Employee);
                var itemExists = context.Items.Any(i => order.Items.Any(oi => oi.Name == i.Name));
                var IsValidOrder = IsValid(order);
                var IsOrderTypeValid = Enum.TryParse(order.Type, out OrderType type);

                if (!IsValidOrder || !employeeExists || !itemExists || !IsOrderTypeValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var current = new Order
                {
                    Customer = order.Customer,
                    DateTime = DateTime.ParseExact(order.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = (OrderType)Enum.Parse(typeof(OrderType), order.Type, true),
                    Employee = context.Employees.FirstOrDefault(e => e.Name == order.Employee),
                    OrderItems = order.Items.Select(i => new OrderItem
                    {
                        Item = context.Items.FirstOrDefault(it => it.Name == i.Name),
                        Order = context.Orders.FirstOrDefault(o => o.Id == order.Id),
                        Quantity = order.Items.Where(it => it.Name == context.Items.FirstOrDefault(x => x.Name == i.Name).Name).Sum(s => s.Quantity)
                    }).ToList()
                };

                orders.Add(current);
                sb.AppendLine($"Order for {order.Employee} on {current.DateTime} added");
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}