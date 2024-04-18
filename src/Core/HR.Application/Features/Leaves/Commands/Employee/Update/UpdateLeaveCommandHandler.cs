using AutoMapper;
using HR.Data.Contexts;
using MediatR;
using HR.Domain.Enums;
using HR.Schema.Response;

namespace HR.Application.Features.Leaves.Commands.Employee.Update;
public class UpdateLeaveCommandHandler(HrDbContext dbContext) :
    IRequestHandler<UpdateLeaveCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;

    public async Task<ApiResponse> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
    {

        var leave = await dbContext.Leaves.FindAsync([request.LeaveId], cancellationToken: cancellationToken);

        if (leave == null)
            return new ApiResponse("Not Found!");

        if (request.UserId != leave.CreatorEmployeeId)
            return new ApiResponse("You have not access to update this leave");

        if (leave.ApprovalStatus != ApprovalStatus.Pending)
            return new ApiResponse("Only pending leaves could be updated");

        leave.StartDate = request.Model.StartDate;
        leave.EndDate = request.Model.EndDate;
        leave.NumberOfDays = (int)(leave.EndDate - leave.StartDate).TotalDays;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}