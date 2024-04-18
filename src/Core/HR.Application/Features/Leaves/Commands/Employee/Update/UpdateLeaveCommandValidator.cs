using FluentValidation;

namespace HR.Application.Features.Leaves.Commands.Employee.Update;

public class UpdateLeaveCommandValidator : AbstractValidator<UpdateLeaveCommandRequest>
{
    public UpdateLeaveCommandValidator()
    {
        RuleFor(x => x.LeaveType).NotEmpty().IsInEnum();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("Start date must be less than or equal to end date.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Now.Date)
            .WithMessage("Start date must not be in the past.");

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(DateTime.Now.Date)
            .WithMessage("End date must not be in the past.");
    }
}
