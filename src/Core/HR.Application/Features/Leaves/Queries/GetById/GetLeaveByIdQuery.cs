using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Queries.GetById;
public record GetLeaveByIdQuery(int EmployeeId, int LeaveId, string Role) : IRequest<ApiResponse<LeaveResponse>>;