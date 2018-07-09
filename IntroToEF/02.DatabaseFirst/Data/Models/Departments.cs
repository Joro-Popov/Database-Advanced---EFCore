using System;
using System.Collections.Generic;

namespace P02.DatabaseFirst.Data.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public Employees Manager { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
