using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Leaves.Commands.Manager.Reject;
public class RejectLeaveCommandHandler(HrDbContext dbContext)
    : IRequestHandler<RejectLeaveCommand, ApiResponse>

{
    public async Task<ApiResponse> Handle(RejectLeaveCommand request, CancellationToken cancellationToken)
    {
        var leaves = await dbContext.Leaves.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (leaves.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending leaves could be rejected");

        foreach (var leave in leaves)
        {
            leave.ApprovalStatus = ApprovalStatus.Rejected;
            leave.ResponseDate = DateTime.Now;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
