using HR.Data.Entities;
using HR.Data.Enums;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Employee.Create;

public record CreateAdvanceCommand(int EmployeeId, CreateAdvanceCommandRequest Model) : IRequest<ApiResponse>;

public record CreateAdvanceCommandRequest(int AdvanceType, decimal Amount, int CurrencyType, string Description);
