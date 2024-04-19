using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Employee.Cancel;

public record CancelAdvanceCommand(int EmployeeId, int AdvanceId) : IRequest<ApiResponse>;