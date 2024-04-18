using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Manager.Reject;

public record RejectAdvanceCommand(ICollection<int> Id) : IRequest<ApiResponse>;