namespace P10_DeptsWithMoreThan5Empl
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var departments = context.Departments
                    .Where(d => d.Employees.Count() > 5)
                    .Select(d => new
                    {
                        d.Name,
                        ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                        Employees = d.Employees.Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName),
                        EmployeesCount = d.Employees.Count()
                    })
                    .OrderBy(d => d.EmployeesCount)
                    .ThenBy(d => d.Name);

                foreach (var dept in departments)
                {
                    Console.WriteLine($"{dept.Name} - {dept.ManagerName}");

                    foreach (var emp in dept.Employees)
                    {
                        Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                    }
                    Console.WriteLine("----------");
                }
            }
        }
    }
}