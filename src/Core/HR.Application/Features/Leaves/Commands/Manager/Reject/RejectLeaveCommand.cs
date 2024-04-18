using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Commands.Manager.Reject;

public record RejectLeaveCommand(ICollection<int> Id) : IRequest<ApiResponse>;