using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Expenses.Commands.Employee.Create;

public record CreateExpenseCommand(int EmployeeId, string File, CreateExpenseCommandRequest Model) : IRequest<ApiResponse>;

public record CreateExpenseCommandRequest(int ExpenseType, decimal Amount, int CurrencyType);