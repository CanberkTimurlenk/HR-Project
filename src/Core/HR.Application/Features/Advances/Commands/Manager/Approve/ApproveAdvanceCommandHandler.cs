using HR.Application.Contracts.Repositories.Advances;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Manager.Approve;
public class ApproveAdvanceCommandHandler(IAdvanceRepository advanceRepository)
    : IRequestHandler<ApproveAdvanceCommand, ApiResponse>
{
    private readonly IAdvanceRepository advanceRepository = advanceRepository;

    public async Task<ApiResponse> Handle(ApproveAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advances = await advanceRepository.GetAllAsync(cancellationToken, a => request.Id.Contains(a.Id));

        if (advances.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending advances could be approved");

        foreach (var advance in advances)
        {
            advance.ApprovalStatus = ApprovalStatus.Approved;
            advance.ResponseDate = DateTime.Now;
        }

        await advanceRepository.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}