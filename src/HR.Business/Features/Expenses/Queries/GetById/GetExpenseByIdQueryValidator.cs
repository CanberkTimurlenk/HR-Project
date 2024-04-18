using FluentValidation;

namespace HR.Business.Features.Expenses.Queries.GetById;
public class GetExpenseByIdQueryValidator : AbstractValidator<GetExpenseByIdQuery>
{
    public GetExpenseByIdQueryValidator()
    {
        RuleFor(x => x.ExpenseId).NotEmpty();

        RuleFor(x => x.ExpenseId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Expense id must be greater than or equal to 1.");
    }
}
