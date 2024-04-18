using FluentValidation;

namespace HR.Application.Features.Expenses.Commands.Employee.Update;

public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommandRequest>
{
    public UpdateExpenseCommandValidator()
    {
        RuleFor(x => x.ExpenseType)
            .InclusiveBetween(0, 2)
            .WithMessage("Expense type must be between 0 and 2.");


        RuleFor(x => x.Amount).NotEmpty()
            .WithMessage("Amount cannot be empty.");


        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Amount must be greater than or equal to 1.");

        RuleFor(x => x.CurrencyType)
            .InclusiveBetween(0, 5)
            .WithMessage("Currency type must be between 0 and 5.");
    }
}
