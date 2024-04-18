using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Commands.Employee.Update;

public record UpdateLeaveCommand(int UserId, int LeaveId, UpdateLeaveCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateLeaveCommandRequest(int LeaveType, DateTime StartDate, DateTime EndDate);
