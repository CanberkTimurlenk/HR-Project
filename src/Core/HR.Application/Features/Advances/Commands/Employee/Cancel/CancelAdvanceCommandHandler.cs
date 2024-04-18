using HR.Data.Contexts;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Employee.Cancel;
public class CancelAdvanceCommandHandler(HrDbContext dbContext) :
    IRequestHandler<CancelAdvanceCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CancelAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advance = await dbContext.Advances.FindAsync([request.AdvanceId], cancellationToken: cancellationToken);

        if (advance == null)
            return new ApiResponse("Not Found!");

        if (request.UserId != advance.CreatorEmployeeId)
            return new ApiResponse("You have not access to cancel this Advance");

        if (advance.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending advances could be canceled");

        advance.ApprovalStatus = ApprovalStatus.Canceled;
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
