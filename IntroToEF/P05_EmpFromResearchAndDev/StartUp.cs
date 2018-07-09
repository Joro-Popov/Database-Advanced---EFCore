namespace P05_EmpFromResearchAndDev
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
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Department.Name,
                        e.Salary
                    });

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
                }
            }
        }
    }
}