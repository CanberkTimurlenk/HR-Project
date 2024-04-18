using FluentValidation;

namespace HR.Application.Features.Users.Commands.Create;

public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandRequestValidator()
    {
        RuleFor(m => m.TurkishIdentificationNumber)
            .NotEmpty()
            .WithMessage("Turkish Identification Number is required");

        RuleFor(m => m.TurkishIdentificationNumber)
            .Length(11)
            .Matches("^[0-9]+$")
            .WithMessage("Turkish Identification Number must be 11 digits");

        RuleFor(m => m.Firstname)
            .NotEmpty()
            .Matches("^[a-zA-Z]+$")
            .WithMessage("First name is required and should only contain letters");

        RuleFor(m => m.Middlename)
            .Matches("^[a-zA-Z]+$")
            .WithMessage("Middle should only contain letters");

        RuleFor(m => m.Lastname)
            .NotEmpty()
            .Matches("^[a-zA-Z]+$")
            .WithMessage("Last name is required and should only contain letters");

        RuleFor(m => m.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Valid Email is required");

        RuleFor(m => m.DateOfBirth)
            .NotEmpty()
            .LessThan(DateTime.Now)
            .WithMessage("Date of Birth is required and should be in the past");

        RuleFor(m => m.DateOfEmployment)
            .NotEmpty()
            .LessThan(DateTime.Now)
            .WithMessage("Date of Employment is required and should be in the past");

        RuleFor(m => m.Company)
            .NotEmpty()
            .WithMessage("Company is required");

        RuleFor(m => m.Position)
            .NotEmpty()
            .WithMessage("Position is required");

        RuleFor(m => m.Department)
            .NotEmpty()
            .WithMessage("Department is required");

        RuleFor(m => m.Address)
            .NotEmpty()
            .WithMessage("Address is required");

        RuleFor(m => m.City)
            .NotEmpty()
            .WithMessage("City is required");

        RuleFor(m => m.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\d{10}$")
            .WithMessage("Phone number is required and should consist of a total of 10 digits");

        RuleFor(m => m.Salary)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Salary is required and should be greater than 0");

        //RuleFor(m => m.DateOfDismissal)
        //    .GreaterThanOrEqualTo(m => m.DateOfEmployment)
        //    .When(m => m.DateOfDismissal.HasValue)
        //    .WithMessage("Date of Dismissal should be later than Date of Employment");

        RuleFor(m => m.Email)
        .NotEmpty()
        .Must((manager, email) => email.Equals($"{manager.Firstname.ToLower()}.{manager.Lastname.ToLower()}@bilgeadamboost.com", StringComparison.CurrentCultureIgnoreCase))
        .WithMessage("Email must be in the format 'yourFirstname.yourLastname@bilgeadamboost.com'");
    }
}