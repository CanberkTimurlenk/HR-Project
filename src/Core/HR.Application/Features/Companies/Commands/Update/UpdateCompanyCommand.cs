using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Companies.Commands.Update;

public record UpdateCompanyCommand(int Id, string LogoFile, UpdateCompanyCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateCompanyCommandRequest(string PhoneNumber, string Address);