using AutoMapper;
using HR.Business.Features.Expenses.Commands.Employee.Create;
using HR.Data.Entities.Concrete;
using HR.Schema;

namespace HR.Business.Features.Expenses.Profiles;

public class ExpenseMappingProfile : Profile
{
    public ExpenseMappingProfile()
    {
        //CreateMap<Expense, ExpenseResponse>()
        //    .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.User.Firstname))
        //    .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.User.Lastname))
        //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

        //CreateMap<CreateExpenseCommandRequest, Expense>();
    }
}
