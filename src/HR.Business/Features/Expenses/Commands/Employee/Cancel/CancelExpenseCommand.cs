using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Expenses.Commands.Employee.Cancel;

public record CancelExpenseCommand(int UserId, int ExpenseId) : IRequest<ApiResponse>;