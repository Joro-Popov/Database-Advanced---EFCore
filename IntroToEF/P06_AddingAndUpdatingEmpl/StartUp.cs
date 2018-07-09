namespace P06_AddingAndUpdatingEmpl
{
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data;
    using P02_DatabaseFirst.Data.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            using (var context = new SoftUniContext())
            {
                var employee = context.Employees
                    .FirstOrDefault(e => e.LastName == "Nakov");

                employee.Address = newAddress;

                context.SaveChanges();

                var addresses = context.Employees
                    .Include(e => e.Address)
                    .OrderByDescending(e => e.AddressId)
                    .Select(e => new
                    {
                        e.Address.AddressText
                    })
                    .Take(10);

                Console.WriteLine(string.Join("\r\n", addresses.Select(a => a.AddressText)));
            }
        }
    }
}