using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.GetByParameter;

public record GetAdvancesByParameterQuery(int? EmployeeId, int UserId, string Role) : IRequest<ApiResponse<IEnumerable<AdvanceResponse>>>;