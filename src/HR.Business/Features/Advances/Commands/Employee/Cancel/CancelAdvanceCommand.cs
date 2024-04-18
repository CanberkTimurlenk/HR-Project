using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Advances.Commands.Employee.Cancel;

public record CancelAdvanceCommand(int UserId, int AdvanceId) : IRequest<ApiResponse>;