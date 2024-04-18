using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Advances.Commands.Employee.Update;

public record UpdateAdvanceCommand(int UserId, int AdvanceId, UpdateAdvanceCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateAdvanceCommandRequest(int AdvanceType, decimal Amount, int CurrencyType);