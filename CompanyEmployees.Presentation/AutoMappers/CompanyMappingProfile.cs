using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTrasferObjects;

namespace CompanyEmployees.Presentation.AutoMappers;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Company, CompanyForCreationDto>().ReverseMap();
    }
}