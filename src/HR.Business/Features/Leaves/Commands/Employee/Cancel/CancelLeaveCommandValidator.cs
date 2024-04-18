using FluentValidation;

namespace HR.Business.Features.Leaves.Commands.Employee.Cancel;

public class CancelLeaveCommandValidator : AbstractValidator<CancelLeaveCommand>
{
    public CancelLeaveCommandValidator()
    {
        RuleFor(x => x.LeaveId).NotEmpty();

        RuleFor(x => x.LeaveId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Leave id must be greater than or equal to 1.");
    }
}
