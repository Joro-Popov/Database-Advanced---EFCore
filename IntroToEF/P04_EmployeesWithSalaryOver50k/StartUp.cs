namespace P04_EmployeesWithSalaryOver50k
{
    using P02_DatabaseFirst.Data;
    using P02_DatabaseFirst.Data.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .OrderBy(e => e.FirstName)
                    .Select(e => new Employee()
                    {
                        FirstName = e.FirstName,
                        Salary = e.Salary
                    })
                    .Where(e => e.Salary > 50000)
                    .ToList();

                foreach (var e in employees)
                {
                    Console.WriteLine(e.FirstName);
                }
            }
        }
    }
}