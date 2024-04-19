using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.Manager.GetByParameter;

public record GetAdvancesByParameterQuery(int? EmployeeId) : IRequest<ApiResponse<IEnumerable<AdvanceResponse>>>;