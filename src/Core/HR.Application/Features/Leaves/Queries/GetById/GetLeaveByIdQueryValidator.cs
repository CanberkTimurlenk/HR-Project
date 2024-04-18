using FluentValidation;

namespace HR.Application.Features.Leaves.Queries.GetById;
public class GetLeaveByIdQueryValidator : AbstractValidator<GetLeaveByIdQuery>
{
    public GetLeaveByIdQueryValidator()
    {
        RuleFor(x => x.LeaveId).NotEmpty();

        RuleFor(x => x.LeaveId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Leave id must be greater than or equal to 1.");

    }
}
