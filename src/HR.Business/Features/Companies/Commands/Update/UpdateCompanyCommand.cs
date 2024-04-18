using HR.Base.Response;
using MediatR;

namespace HR.Business.Companies.Commands.Update;

public record UpdateCompanyCommand(int Id, string LogoFile, UpdateCompanyCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateCompanyCommandRequest(string PhoneNumber, string Address);