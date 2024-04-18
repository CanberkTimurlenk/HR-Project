using AutoMapper;
using HR.Business.Features.Advances.Commands.Employee.Create;
using HR.Data.Entities.Concrete;
using HR.Schema;

namespace HR.Application.Features.Advances.Profiles;

public class AdvanceMappingProfile : Profile
{
    public AdvanceMappingProfile()
    {
        //CreateMap<Advance, AdvanceResponse>()
        //    .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.Firstname))
        //    .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.Lastname))
        //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

        //CreateMap<CreateAdvanceCommandRequest, Advance>();
    }
}
