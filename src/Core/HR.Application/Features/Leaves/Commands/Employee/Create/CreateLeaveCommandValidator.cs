using FluentValidation;

namespace HR.Application.Features.Leaves.Commands.Employee.Create;

public class CreateLeaveCommandRequestValidator : AbstractValidator<CreateLeaveCommandRequest>
{
    public CreateLeaveCommandRequestValidator()
    {
        RuleFor(x => x.LeaveType).InclusiveBetween(0, 2);
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

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage("End date must be greater than or equal to start date.");
    }
}
