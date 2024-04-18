using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Leaves.Commands.Employee.Create;

public record CreateLeaveCommand(int EmployeeId, CreateLeaveCommandRequest Model) : IRequest<ApiResponse>;

public record CreateLeaveCommandRequest(int LeaveType, DateTime StartDate, DateTime EndDate);
