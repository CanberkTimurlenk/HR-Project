using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Employee.Cancel;

public record CancelAdvanceCommand(int UserId, int AdvanceId) : IRequest<ApiResponse>;