using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Expenses.Commands.Manager.Approve;
public record ApproveExpenseCommand(ICollection<int> Id) : IRequest<ApiResponse>;