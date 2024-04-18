using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Advances.Commands.Manager.Approve;
public record ApproveAdvanceCommand(ICollection<int> Id) : IRequest<ApiResponse>;