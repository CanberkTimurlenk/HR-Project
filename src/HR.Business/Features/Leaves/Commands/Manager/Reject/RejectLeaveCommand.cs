using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Leaves.Commands.Manager.Reject;

public record RejectLeaveCommand(ICollection<int> Id) : IRequest<ApiResponse>;