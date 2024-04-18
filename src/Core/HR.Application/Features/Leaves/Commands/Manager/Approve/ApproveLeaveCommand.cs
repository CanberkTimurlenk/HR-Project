using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Commands.Manager.Approve;
public record ApproveLeaveCommand(ICollection<int> Id) : IRequest<ApiResponse>;