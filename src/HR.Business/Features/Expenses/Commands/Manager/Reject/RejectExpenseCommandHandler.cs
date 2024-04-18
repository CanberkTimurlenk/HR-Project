using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Expenses.Commands.Manager.Reject;
public class RejectExpenseCommandHandler(HrDbContext dbContext)
    : IRequestHandler<RejectExpenseCommand, ApiResponse>

{
    public async Task<ApiResponse> Handle(RejectExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenses = await dbContext.Expenses.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (expenses.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending expenses could be rejected");

        foreach (var expense in expenses)
        {
            expense.ApprovalStatus = ApprovalStatus.Rejected;
            expense.ResponseDate = DateTime.Now;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
