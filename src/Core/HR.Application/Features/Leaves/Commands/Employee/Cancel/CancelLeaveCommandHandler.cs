using HR.Data.Contexts;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Leaves.Commands.Employee.Cancel;
public class CancelLeaveCommandHandler(HrDbContext dbContext) :
    IRequestHandler<CancelLeaveCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CancelLeaveCommand request, CancellationToken cancellationToken)
    {
        var leave = await dbContext.Leaves.FindAsync([request.LeaveId], cancellationToken: cancellationToken);

        if (leave == null)
            return new ApiResponse("Not Found!");

        if (request.UserId != leave.CreatorEmployeeId)
            return new ApiResponse("You have not access to cancel this leave");

        if (leave.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending leaves could be canceled");

        leave.ApprovalStatus = ApprovalStatus.Canceled;
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
