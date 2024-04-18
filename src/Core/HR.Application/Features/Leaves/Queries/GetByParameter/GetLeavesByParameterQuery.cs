using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Queries.GetByParameter;

public record GetLeavesByParameterQuery(int? EmployeeId, int UserId, string Role) : IRequest<ApiResponse<IEnumerable<LeaveResponse>>>;