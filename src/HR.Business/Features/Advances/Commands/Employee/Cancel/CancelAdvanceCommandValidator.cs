using FluentValidation;

namespace HR.Business.Features.Advances.Commands.Employee.Cancel;

public class CancelAdvanceCommandValidator : AbstractValidator<CancelAdvanceCommand>
{
    public CancelAdvanceCommandValidator()
    {
        RuleFor(x => x.AdvanceId).NotEmpty();

        RuleFor(x => x.AdvanceId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Advance id must be greater than or equal to 1.");
    }
}
