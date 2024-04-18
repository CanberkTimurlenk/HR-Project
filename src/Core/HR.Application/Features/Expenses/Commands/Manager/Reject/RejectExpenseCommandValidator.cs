using FluentValidation;

namespace HR.Application.Features.Expenses.Commands.Manager.Reject;

public class RejectExpenseCommandValidator : AbstractValidator<RejectExpenseCommand>
{
    public RejectExpenseCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotNull().WithMessage("Id collection cannot be null.")
            .NotEmpty().WithMessage("Id collection cannot be empty.")
            .Must(ids => ids.All(id => id > 0)).WithMessage("Each id must be greater than 0.");
    }
}