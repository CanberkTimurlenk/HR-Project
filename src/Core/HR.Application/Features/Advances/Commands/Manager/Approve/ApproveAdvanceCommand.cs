using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Manager.Approve;
public record ApproveAdvanceCommand(ICollection<int> Id) : IRequest<ApiResponse>;