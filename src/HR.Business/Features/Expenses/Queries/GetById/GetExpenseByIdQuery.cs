using HR.Base.Response;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Expenses.Queries.GetById;
public record GetExpenseByIdQuery(int EmployeeId, int ExpenseId, string Role) : IRequest<ApiResponse<ExpenseResponse>>;