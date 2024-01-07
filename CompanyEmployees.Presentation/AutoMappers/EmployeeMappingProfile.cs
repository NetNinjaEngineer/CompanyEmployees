using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTrasferObjects;

namespace CompanyEmployees.Presentation.AutoMappers;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, EmployeeForUpdateDto>().ReverseMap();
    }
}
