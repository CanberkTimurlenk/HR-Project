using FluentValidation;

namespace HR.Application.Features.Advances.Commands.Manager.Reject;

public class RejectAdvanceCommandValidator : AbstractValidator<RejectAdvanceCommand>
{
    public RejectAdvanceCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull().WithMessage("Id collection cannot be null.")
            .NotEmpty().WithMessage("Id collection cannot be empty.")
            .Must(ids => ids.All(id => id > 0)).WithMessage("Each id must be greater than 0.");
    }
}