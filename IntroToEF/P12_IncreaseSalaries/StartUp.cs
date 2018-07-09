namespace P12_IncreaseSalaries
{
    using P02_DatabaseFirst.Data;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.DepartmentId == 1 || e.DepartmentId == 2 || e.DepartmentId == 4 || e.DepartmentId == 11);

                foreach (var emp in employees)
                {
                    emp.Salary += (emp.Salary * 0.12m);
                }

                context.SaveChanges();

                var emps = employees
                   .OrderBy(e => e.FirstName)
                   .ThenBy(e => e.LastName);

                foreach (var emp in emps)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
                }
            }
        }
    }
}