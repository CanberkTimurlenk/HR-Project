using HR.Data.Contexts;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.Advances.Commands.Manager.Reject;
public class RejectAdvanceCommandHandler(HrDbContext dbContext)
    : IRequestHandler<RejectAdvanceCommand, ApiResponse>

{
    public async Task<ApiResponse> Handle(RejectAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advances = await dbContext.Advances.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (advances.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending advances could be rejected");

        foreach (var advance in advances)
        {
            advance.ApprovalStatus = ApprovalStatus.Rejected;
            advance.ResponseDate = DateTime.Now;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
