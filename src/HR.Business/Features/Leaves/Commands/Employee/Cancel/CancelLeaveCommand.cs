using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Leaves.Commands.Employee.Cancel;

public record CancelLeaveCommand(int UserId, int LeaveId) : IRequest<ApiResponse>;