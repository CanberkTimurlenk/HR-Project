using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Expenses.Commands.Employee.Cancel;

public record CancelExpenseCommand(int UserId, int ExpenseId) : IRequest<ApiResponse>;