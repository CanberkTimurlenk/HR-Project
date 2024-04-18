using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Expenses.Commands.Manager.Reject;

public record RejectExpenseCommand(ICollection<int> Id) : IRequest<ApiResponse>;