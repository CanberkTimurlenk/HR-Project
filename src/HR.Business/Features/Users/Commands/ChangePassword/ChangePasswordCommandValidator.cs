using FluentValidation;
using HR.Business.Users.Commands.ChangePassword;

namespace HR.Business.Features.Users.Commands.ChangePassword;

public class ResetPasswordCommandValidator
    : AbstractValidator<ChangePasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.ResetPasswordGuid).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();

        RuleFor(x => x.Password)
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
            .WithMessage("Password must contain at least 8 characters, including at least one letter and one number");
    }
}
