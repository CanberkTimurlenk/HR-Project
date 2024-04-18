using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Expenses.Queries.GetById;
public record GetExpenseByIdQuery(int EmployeeId, int ExpenseId, string Role) : IRequest<ApiResponse<ExpenseResponse>>;