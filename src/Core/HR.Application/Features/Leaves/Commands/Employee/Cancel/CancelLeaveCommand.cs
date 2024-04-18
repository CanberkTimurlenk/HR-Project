using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Commands.Employee.Cancel;

public record CancelLeaveCommand(int UserId, int LeaveId) : IRequest<ApiResponse>;