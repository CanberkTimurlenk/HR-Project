using FluentValidation;

namespace HR.Business.Features.Leaves.Commands.Manager.Reject;

public class RejectLeaveCommandValidator : AbstractValidator<RejectLeaveCommand>
{
    public RejectLeaveCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull().WithMessage("Id collection cannot be null.")
            .NotEmpty().WithMessage("Id collection cannot be empty.")
            .Must(ids => ids.All(id => id > 0)).WithMessage("Each id must be greater than 0.");
    }
}