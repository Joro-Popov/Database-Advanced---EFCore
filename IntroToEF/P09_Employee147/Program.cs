namespace P09_Employee147
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
                var employee147 = context.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        e.JobTitle,
                        Projects = e.EmployeesProjects
                        .Select(p => new
                        {
                            p.Project.Name
                        })
                        .OrderBy(p => p.Name)
                    })
                    .SingleOrDefault();

                Console.WriteLine($"{employee147.Name} - {employee147.JobTitle}");

                foreach (var proj in employee147.Projects)
                {
                    Console.WriteLine(proj.Name);
                }
            }
        }
    }
}