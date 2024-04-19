using MediatR;
using HR.Domain.Enums;
using HR.Schema.Response;
using HR.Application.Contracts.Repositories.Advances;

namespace HR.Application.Features.Advances.Commands.Employee.Update;
public class UpdateAdvanceCommandHandler(IAdvanceRepository advanceRepository) :
    IRequestHandler<UpdateAdvanceCommand, ApiResponse>
{
    private readonly IAdvanceRepository advanceRepository = advanceRepository;

    public async Task<ApiResponse> Handle(UpdateAdvanceCommand request, CancellationToken cancellationToken)
    {
        var expense = await advanceRepository.FindAsync(request.AdvanceId, cancellationToken);

        if (expense == null)
            return new ApiResponse("Not Found!");

        if (request.EmployeeId != expense.CreatorEmployeeId)
            return new ApiResponse("You have not access to update this advance");

        if (expense.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending advance could be updated");

        expense.CurrencyType = (CurrencyType)request.Model.CurrencyType;
        expense.Amount = request.Model.Amount;

        await advanceRepository.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}