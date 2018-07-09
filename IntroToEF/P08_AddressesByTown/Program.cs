namespace P08_AddressesByTown
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .Select(a => new
                    {
                        a.AddressText,
                        a.Town.Name,
                        EmployeeCount = a.Employees.Count()
                    })
                    .OrderByDescending(a => a.EmployeeCount)
                    .ThenBy(a => a.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10);

                foreach (var a in addresses)
                {
                    Console.WriteLine($"{a.AddressText}, {a.Name} - {a.EmployeeCount} employees");
                }
            }
        }
    }
}