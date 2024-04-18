using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Expenses.Commands.Manager.Reject;

public record RejectExpenseCommand(ICollection<int> Id) : IRequest<ApiResponse>;