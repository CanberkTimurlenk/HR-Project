using FluentValidation;
using HR.Business.Users.Commands.ChangePassword;

namespace HR.Business.Features.Users.Commands.ResetPassword;

public class ResetPasswordCommandValidator
    : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.NewPassword)
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
            .WithMessage("Password must contain at least 8 characters, including at least one letter and one number");
    }
}
