using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Advances.Commands.Manager.Approve;
public class ApproveAdvanceCommandHandler(HrDbContext dbContext)
    : IRequestHandler<ApproveAdvanceCommand, ApiResponse>

{
    public async Task<ApiResponse> Handle(ApproveAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advances = await dbContext.Advances.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (advances.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending advances could be approved");

        foreach (var advance in advances)
        {
            advance.ApprovalStatus = ApprovalStatus.Approved;
            advance.ResponseDate = DateTime.Now;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}