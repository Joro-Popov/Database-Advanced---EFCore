namespace P02_DatabaseFirst
{
    using P02_DatabaseFirst.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var firstEmployee = context.Employees
                    .Find(1);

                Console.WriteLine(firstEmployee.FirstName);
            }
        }
    }
}