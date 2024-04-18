using AutoMapper;
using HR.Data.Contexts;
using MediatR;
using HR.Domain.Enums;
using HR.Schema.Response;

namespace HR.Application.Features.Expenses.Commands.Employee.Update;
public class UpdateExpenseCommandHandler(HrDbContext dbContext) :
    IRequestHandler<UpdateExpenseCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;

    public async Task<ApiResponse> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {

        var expense = await dbContext.Expenses.FindAsync([request.ExpenseId], cancellationToken: cancellationToken);

        if (expense == null)
            return new ApiResponse("Not Found!");

        if (request.UserId != expense.CreatorEmployeeId)
            return new ApiResponse("You have not access to update this expense");

        if (expense.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending expenses could be updated");

        expense.CurrencyType = (CurrencyType)request.Model.CurrencyType;
        expense.Amount = request.Model.Amount;
        //expense.ExpenseType = (ExpenseType)request.Model.ExpenseType;




        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}