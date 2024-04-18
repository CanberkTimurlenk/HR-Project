using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Leaves.Commands.Employee.Update;

public record UpdateLeaveCommand(int UserId, int LeaveId, UpdateLeaveCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateLeaveCommandRequest(int LeaveType, DateTime StartDate, DateTime EndDate);
