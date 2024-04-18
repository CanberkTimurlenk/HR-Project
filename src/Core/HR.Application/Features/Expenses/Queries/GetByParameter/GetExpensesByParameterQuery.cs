using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Expenses.Queries.GetByParameter;

public record GetExpensesByParameterQuery(int? EmployeeId, int UserId, string Role) : IRequest<ApiResponse<IEnumerable<ExpenseResponse>>>;