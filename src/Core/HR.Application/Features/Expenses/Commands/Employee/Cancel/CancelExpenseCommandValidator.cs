using FluentValidation;

namespace HR.Application.Features.Expenses.Commands.Employee.Cancel;

public class CancelExpenseCommandValidator : AbstractValidator<CancelExpenseCommand>
{
    public CancelExpenseCommandValidator()
    {
        RuleFor(x => x.ExpenseId).NotEmpty();

        RuleFor(x => x.ExpenseId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Expense id must be greater than or equal to 1.");
    }
}
