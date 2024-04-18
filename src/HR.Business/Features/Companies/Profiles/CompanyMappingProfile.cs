using AutoMapper;
using HR.Business.Companies.Commands.Create;
using HR.Data.Entities.Concrete;
using HR.Schema;

namespace HR.Business.Features.Companies.Profiles;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, CompanyResponse>();
        CreateMap<CreateCompanyCommandRequest, Company>();
    }
}
