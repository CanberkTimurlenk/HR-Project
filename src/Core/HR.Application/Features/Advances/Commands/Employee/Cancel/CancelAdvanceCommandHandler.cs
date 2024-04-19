using HR.Application.Contracts.Repositories.Admins;
using HR.Application.Contracts.Repositories.Advances;
using HR.Domain.Enums;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Commands.Employee.Cancel;
public class CancelAdvanceCommandHandler(IAdvanceRepository advanceRepository) :
    IRequestHandler<CancelAdvanceCommand, ApiResponse>
{
    private readonly IAdvanceRepository advanceRepository = advanceRepository;

    public async Task<ApiResponse> Handle(CancelAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advance = await advanceRepository.FindAsync(request.AdvanceId, cancellationToken);

        if (advance == null)
            return new ApiResponse("Not Found!");

        if (request.EmployeeId != advance.CreatorEmployeeId)
            return new ApiResponse("You have not access to cancel this Advance");

        if (advance.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending advances could be canceled");

        advance.ApprovalStatus = ApprovalStatus.Canceled;
        advanceRepository.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
