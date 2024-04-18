using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using MediatR;
using HR.Data.Enums;

namespace HR.Business.Features.Advances.Commands.Employee.Update;
public class UpdateAdvanceCommandHandler(HrDbContext dbContext) :
    IRequestHandler<UpdateAdvanceCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;

    public async Task<ApiResponse> Handle(UpdateAdvanceCommand request, CancellationToken cancellationToken)
    {

        var expense = await dbContext.Advances.FindAsync([request.AdvanceId], cancellationToken: cancellationToken);

        if (expense == null)
            return new ApiResponse("Not Found!");

        if (request.UserId != expense.CreatorEmployeeId)
            return new ApiResponse("You have not access to update this advance");

        if (expense.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending advance could be updated");

        expense.CurrencyType = (CurrencyType)request.Model.CurrencyType;
        expense.Amount = request.Model.Amount;
        //expense.AdvanceType = (AdvanceType)request.Model.AdvanceType;




        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}