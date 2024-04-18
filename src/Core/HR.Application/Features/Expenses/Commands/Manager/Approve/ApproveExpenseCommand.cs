using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Expenses.Commands.Manager.Approve;
public record ApproveExpenseCommand(ICollection<int> Id) : IRequest<ApiResponse>;