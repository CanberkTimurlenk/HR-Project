using HR.Base.Response;
using HR.Data.Entities;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Companies.Queries.GetById;

public record GetCompanyByIdQuery(int Id) : IRequest<ApiResponse<CompanyResponse>>;