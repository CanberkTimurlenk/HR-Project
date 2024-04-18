using HR.Data.Entities;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Companies.Queries.GetAll;

public record GetAllCompaniesQuery() : IRequest<ApiResponse<IEnumerable<CompanyResponse>>>;