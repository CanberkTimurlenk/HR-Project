using AutoMapper;
using HR.Application.Features.Companies.Commands.Create;
using HR.Domain.Entities.Concrete;
using HR.Schema.Response;

namespace HR.Application.Features.Companies.Profiles;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, CompanyResponse>();
        CreateMap<CreateCompanyCommandRequest, Company>();
    }
}
