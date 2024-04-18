using HR.Data.Contexts;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.Expenses.Commands.Manager.Approve;
public class ApproveExpenseCommandHandler(HrDbContext dbContext)
    : IRequestHandler<ApproveExpenseCommand, ApiResponse>

{
    public async Task<ApiResponse> Handle(ApproveExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenses = await dbContext.Expenses.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (expenses.Any(x => x.ApprovalStatus != ApprovalStatus.Pending))
            return new ApiResponse("Only pending expenses could be approved");

        foreach (var expense in expenses)
        {
            expense.ApprovalStatus = ApprovalStatus.Approved;
            expense.ResponseDate = DateTime.Now;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}
