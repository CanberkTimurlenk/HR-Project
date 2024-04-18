using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Commands.Employee.Create;

public record CreateLeaveCommand(int EmployeeId, CreateLeaveCommandRequest Model) : IRequest<ApiResponse>;

public record CreateLeaveCommandRequest(int LeaveType, DateTime StartDate, DateTime EndDate);
