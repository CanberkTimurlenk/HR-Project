using HR.Base.Response;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Leaves.Queries.GetById;
public record GetLeaveByIdQuery(int EmployeeId, int LeaveId, string Role) : IRequest<ApiResponse<LeaveResponse>>;