using HR.Base.Response;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Expenses.Queries.GetByParameter;

public record GetExpensesByParameterQuery(int? EmployeeId, int UserId, string Role) : IRequest<ApiResponse<IEnumerable<ExpenseResponse>>>;