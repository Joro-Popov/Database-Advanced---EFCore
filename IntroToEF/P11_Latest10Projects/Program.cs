namespace P11_Latest10Projects
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var last10Projects = context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                    });

                foreach (var proj in last10Projects)
                {
                    Console.WriteLine($"{proj.Name}\r\n" +
                                      $"{proj.Description}\r\n" +
                                      $"{proj.StartDate}");
                }
            }
        }
    }
}