namespace P14_DeleteProjectById
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
                var projToDelete = context.Projects.Find(2);
                var empProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

                context.EmployeesProjects.RemoveRange(empProjects);
                context.Projects.Remove(projToDelete);

                context.SaveChanges();

                var First10Projects = context.Projects
                    .Select(p => new
                    {
                        p.Name
                    })
                    .Take(10);

                foreach (var proj in First10Projects)
                {
                    Console.WriteLine(proj.Name);
                }
            }
        }
    }
}