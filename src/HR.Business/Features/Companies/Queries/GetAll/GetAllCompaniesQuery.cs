using HR.Base.Response;
using HR.Data.Entities;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Companies.Queries.GetByParameter;

public record GetAllCompaniesQuery() : IRequest<ApiResponse<IEnumerable<CompanyResponse>>>;