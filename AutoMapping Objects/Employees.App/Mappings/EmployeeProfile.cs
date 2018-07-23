namespace Employees.App.Mappings
{
    using AutoMapper;
    using Employees.App.DTOModels;
    using Employees.Models;

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();

            CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeesCount,
                           opt => opt.MapFrom(x => x.ManagedEmployees.Count));

            CreateMap<Employee, EmployeesManagersDto>()
                .ForMember(dto => dto.ManagerName,
                           opt => opt.MapFrom(x => x.Manager.FirstName));
        }
    }
}