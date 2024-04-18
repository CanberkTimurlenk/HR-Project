using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Enums;
using MediatR;

namespace HR.Business.Features.Expenses.Commands.Employee.Cancel;
public class CancelExpenseCommandHandler(HrDbContext dbContext) :
    IRequestHandler<CancelExpenseCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CancelExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await dbContext.Expenses.FindAsync([request.ExpenseId], cancellationToken: cancellationToken);

        if (expense == null)
            return new ApiResponse("Not Found!");

        if (request.UserId != expense.CreatorEmployeeId)
            return new ApiResponse("You have not access to cancel this expense");

        if (expense.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending expenses could be canceled");

        expense.ApprovalStatus = ApprovalStatus.Canceled;
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
