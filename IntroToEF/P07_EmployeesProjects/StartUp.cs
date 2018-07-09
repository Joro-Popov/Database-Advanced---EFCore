namespace P07_EmployeesProjects
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.EmployeesProjects.Any(ep =>
                                ep.Project.StartDate.Year >= 2001 &&
                                ep.Project.StartDate.Year <= 2003
                    ))
                    .Take(30)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Manager = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects.Select(p => new
                        {
                            p.Project.Name,
                            p.Project.StartDate,
                            p.Project.EndDate
                        })
                    })
                    .ToList();

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.Name} - Manager: {emp.Manager}");

                    foreach (var proj in emp.Projects)
                    {
                        if (proj.EndDate == null)
                        {
                            Console.WriteLine($"--{proj.Name} - {proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - not finished");
                        }
                        else
                        {
                            Console.WriteLine($"--{proj.Name} - {proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {proj.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
            }
        }
    }
}