using AutoMapper;
using HR.Business.Features.Leaves.Commands.Employee.Create;
using HR.Data.Entities.Concrete;
using HR.Schema;

namespace HR.Application.Features.Leaves.Profiles;

public class LeaveMappingProfile : Profile
{
    public LeaveMappingProfile()
    {
        //CreateMap<Leave, LeaveResponse>()
        //    .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.Firstname))
        //    .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.Lastname))
        //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

        //CreateMap<CreateLeaveCommandRequest, Leave>();
    }
}
