using FluentValidation;

namespace HR.Business.Features.Advances.Commands.Manager.Approve;
public class ApproveAdvanceCommandValidator : AbstractValidator<ApproveAdvanceCommand>
{
    public ApproveAdvanceCommandValidator()
    {
        RuleFor(command => command.Id)
                .NotNull().WithMessage("Id collection cannot be null.")
                .NotEmpty().WithMessage("Id collection cannot be empty.")
                .Must(ids => ids.All(id => id > 0)).WithMessage("Each id must be greater than 0.");
    }
}
