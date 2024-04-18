using FluentValidation;

namespace HR.Application.Features.Companies.Commands.Create;

public class CreateCompanyCommandRequestValidator : AbstractValidator<CreateCompanyCommandRequest>
{
    public CreateCompanyCommandRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty.");

        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Name must be at least 3 characters long.");

        RuleFor(x => x.Name)
            .MaximumLength(50)
            .WithMessage("Name cannot be longer than 50 characters.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address cannot be empty.");

        RuleFor(m => m.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\d{10}$")
            .WithMessage("Phone number is required and should consist of a total of 10 digits");

        RuleFor(m => m.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Valid Email is required");

        RuleFor(m => m.TaxOffice)
            .NotEmpty()
            .WithMessage("Tax office is required");

        RuleFor(m => m.TaxNumber)
            .Length(10)
            .Matches("^[0-9]+$")
            .WithMessage("Tax number must be 10 digits");

        RuleFor(m => m.TaxNumber)
            .NotEmpty()
            .WithMessage("Tax number is required");

        RuleFor(m => m.Type)
            .IsInEnum().InclusiveBetween(0, 4);

        RuleFor(m => m.EmployeeCount)
            .NotEmpty()
            .WithMessage("Employee count is required");

        RuleFor(m => m.EmployeeCount)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Employee count must be greater than or equal to 1");

        RuleFor(m => m.EstablishmentYear)
            .NotEmpty()
            .WithMessage("Establishment year is required");

        RuleFor(m => m.EstablishmentYear)
            .InclusiveBetween(1900, DateTime.Now.Year)
            .WithMessage($"Establishment year must be between 1900 and {DateTime.Now.Year}");

        RuleFor(m => m.ContractEndDate)
            .NotEmpty()
            .WithMessage("Contract end date is required");

        RuleFor(m => m.ContractEndDate)
            .GreaterThan(DateTime.Now)
            .WithMessage("Contract end date must be in the future");

        RuleFor(m => m.ContractStartDate)
            .NotEmpty()
            .WithMessage("Contract start date is required");

        RuleFor(m => m.ContractStartDate)
            .LessThan(m => m.ContractEndDate)
            .WithMessage("Contract start date must be before contract end date");
    }
}