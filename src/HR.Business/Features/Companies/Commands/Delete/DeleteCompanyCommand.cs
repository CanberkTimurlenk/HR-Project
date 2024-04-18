using HR.Base.Response;
using MediatR;

namespace HR.Business.Companies.Commands.Delete;

public record DeleteCompanyCommand(int Id) : IRequest<ApiResponse>;