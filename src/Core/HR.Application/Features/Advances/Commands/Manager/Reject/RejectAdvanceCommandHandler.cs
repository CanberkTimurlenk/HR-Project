using HR.Application.Contracts.Repositories.Advances;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Manager.Reject;
public class RejectAdvanceCommandHandler(IAdvanceRepository advanceRepository)
    : IRequestHandler<RejectAdvanceCommand, ApiResponse>

{
    private readonly IAdvanceRepository advanceRepository = advanceRepository;

    public async Task<ApiResponse> Handle(RejectAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advances = await advanceRepository.GetAllAsync(cancellationToken, a => request.Id.Contains(a.Id));

        if (advances.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending advances could be rejected");

        foreach (var advance in advances)
        {
            advance.ApprovalStatus = ApprovalStatus.Rejected;
            advance.ResponseDate = DateTime.Now;
        }

        await advanceRepository.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
