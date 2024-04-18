using FluentValidation;
using HR.Application.Features.Users.Constants;

namespace HR.Application.Features.Companies.Commands.Update;

public class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyCommandRequest>
{
    public UpdateCompanyRequestValidator()
    {
        RuleFor(m => m.Address)
            .NotEmpty()
            .WithMessage("Address is required");

        RuleFor(m => m.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required");

        RuleFor(e => e.PhoneNumber)
            .Matches(RegexValidations.Phone)
            .WithMessage("The phone number must start with +90, consist of a total of 12 digits, and must not contain any spaces.");
    }
}
