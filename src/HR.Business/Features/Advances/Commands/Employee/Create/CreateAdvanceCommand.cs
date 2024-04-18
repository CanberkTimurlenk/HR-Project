using HR.Base.Response;
using HR.Data.Entities;
using HR.Data.Enums;
using MediatR;

namespace HR.Business.Features.Advances.Commands.Employee.Create;

public record CreateAdvanceCommand(int EmployeeId, CreateAdvanceCommandRequest Model) : IRequest<ApiResponse>;

public record CreateAdvanceCommandRequest(int AdvanceType, decimal Amount, int CurrencyType, string Description);
