namespace Employees.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.ManagedEmployees = new List<Employee>();
        }

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> ManagedEmployees { get; set; }
    }
}