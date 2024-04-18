using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Leaves.Commands.Manager.Approve;
public record ApproveLeaveCommand(ICollection<int> Id) : IRequest<ApiResponse>;