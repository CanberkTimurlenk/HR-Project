using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Advances.Commands.Manager.Reject;

public record RejectAdvanceCommand(ICollection<int> Id) : IRequest<ApiResponse>;