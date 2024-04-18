using HR.Data.Entities;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Companies.Queries.GetById;

public record GetCompanyByIdQuery(int Id) : IRequest<ApiResponse<CompanyResponse>>;