namespace Employees.App.Controllers.Contracts
{
    using Employees.App.DTOModels;
    using System;
    using System.Collections.Generic;

    public interface IEmployeesController
    {
        void AddEmployee(EmployeeDto employeeDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId);

        ManagerDto GetManagerInfo(int employeeId);

        string SetManager(int employeeId, int managerId);

        IList<EmployeesManagersDto> ListEmployeesOlderThan(int age);
    }
}