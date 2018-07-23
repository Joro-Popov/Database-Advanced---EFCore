namespace Employees.App.Controllers
{
    using AutoMapper;
    using Employees.App.Constants;
    using Employees.App.Controllers.Contracts;
    using Employees.App.DTOModels;
    using Employees.Data;
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeesController : IEmployeesController
    {
        private readonly EmployeesDbContext context;
        private readonly IMapper mapper;
        private readonly IServiceProvider serviceProvider;

        public EmployeesController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.context = serviceProvider.GetService<EmployeesDbContext>();
            this.mapper = serviceProvider.GetService<IMapper>();
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = this.mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("employee", ErrorMessages.EmployeeNotFound);
            }

            var employeeDto = this.mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("employee", ErrorMessages.EmployeeNotFound);
            }

            var employeeDto = this.mapper.Map<EmployeePersonalInfoDto>(employee);

            return employeeDto;
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("employee", ErrorMessages.EmployeeNotFound);
            }

            employee.Address = address;

            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException("employee", ErrorMessages.EmployeeNotFound);
            }

            employee.Birthday = date;

            this.context.SaveChanges();
        }

        public ManagerDto GetManagerInfo(int managerId)
        {
            var employee = this.context.Employees
                           .Include(m => m.ManagedEmployees)
                           .SingleOrDefault(m => m.EmployeeId == managerId);

            if (employee == null)
            {
                throw new ArgumentNullException("employee", ErrorMessages.EmployeeNotFound);
            }

            var managerDto = mapper.Map<ManagerDto>(employee);

            return managerDto;
        }

        public string SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentNullException("employee", ErrorMessages.EmployeeNotFound);
            }

            employee.Manager = manager ?? throw new ArgumentNullException("manager", ErrorMessages.EmployeeNotFound);

            this.context.SaveChanges();

            return Messages.SuccessfullAddManager;
        }

        public IList<EmployeesManagersDto> ListEmployeesOlderThan(int age)
        {
            var result = new List<EmployeesManagersDto>();

            var employees = context.Employees
                .Where(e => e.Birthday != null && (DateTime.Now.Year - e.Birthday.Value.Year) > age)
                .ToList();

            foreach (var e in employees)
            {
                var employeeToAdd = this.mapper.Map<EmployeesManagersDto>(e);

                result.Add(employeeToAdd);
            }

            return result;
        }
    }
}