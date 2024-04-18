using FluentValidation;

namespace HR.Application.Features.Advances.Commands.Employee.Update;

public class UpdateAdvanceCommandValidator : AbstractValidator<UpdateAdvanceCommandRequest>
{
    public UpdateAdvanceCommandValidator()
    {
        RuleFor(x => x.AdvanceType)
            .InclusiveBetween(0, 2)
            .WithMessage("Advance type must be between 0 and 2.");

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
