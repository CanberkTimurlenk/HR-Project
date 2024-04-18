using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Companies.Commands.Delete;

public record DeleteCompanyCommand(int Id) : IRequest<ApiResponse>;