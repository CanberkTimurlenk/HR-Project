using HR.Schema.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace HR.Application.Features.Users.Commands.Create;

public record CreateUserCommand(string FileName, CreateUserCommandRequest Model) : IRequest<ApiResponse<int>>;


public record CreateUserCommandRequest
{
    public string TurkishIdentificationNumber { get; init; }
    public string Firstname { get; init; }
    public string Middlename { get; init; }
    public string Lastname { get; init; }
    public string Email { get; init; }
    public DateTime DateOfBirth { get; init; }
    public DateTime DateOfEmployment { get; init; }
    public string Company { get; init; }
    public string Position { get; init; }
    public string Department { get; init; }
    public string Address { get; init; }
    public string City { get; init; }
    public string PhoneNumber { get; init; }
    public decimal Salary { get; init; }

}