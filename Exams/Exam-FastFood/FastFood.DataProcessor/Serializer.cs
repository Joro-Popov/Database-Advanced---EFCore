using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            var orders = context.Orders
                .Where(e => e.Employee.Name == employeeName && e.Type.ToString() == orderType)
                .Select(e => new EmployeeDto
                {
                    Name = e.Employee.Name,
                    Orders = e.Employee.Orders.Select(o => new OrderDto
                    {
                        Customer = e.Customer,
                        Items = e.OrderItems.Select(i => new ItemDto
                        {
                            Name = i.Item.Name,
                            Price = i.Item.Price,
                            Quantity = i.Quantity
                        }).ToList(),

                        TotalPrice = o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity)
                    })
                    .OrderByDescending(o => o.Items.Sum(i => i.Price))
                    .ThenByDescending(o => o.Items.Count)
                    .ToList(),

                    TotalMoneyMade = e.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity)
                }).ToList();

            var json = JsonConvert.SerializeObject(orders, Formatting.Indented);

            return json;
		}

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var categories = categoriesString.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            var serializer = new XmlSerializer(typeof(List<CategoryDto>), new XmlRootAttribute("Categories"));
            var namespaces = new XmlSerializerNamespaces(new[] { new System.Xml.XmlQualifiedName("", "") });

            var expCategories = context.Items
                .Where(i => categories.Any(c => c == i.Category.Name))
                .GroupBy(i => i.Category.Name)
                .Select(g => new CategoryDto
                {
                    Name = g.Key,
                    MostPopularItem = g.Select(i => new MostPopularItemDto
                    {
                        Name = i.Name,
                        TotalMade = i.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(i => i.TotalMade)
                    .ThenByDescending(i => i.TimesSold)
                    .First()
                })
                .OrderByDescending(dto => dto.MostPopularItem.TotalMade)
                .ThenByDescending(dto => dto.MostPopularItem.TimesSold)
                .ToList();

            var result = new StringBuilder();

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, expCategories, namespaces);
            }

            return result.ToString().Trim();
		}
    }
}