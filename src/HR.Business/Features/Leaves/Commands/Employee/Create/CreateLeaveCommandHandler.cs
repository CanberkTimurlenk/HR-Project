using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using MediatR;
using HR.Data.Enums;
using HR.Data.Entities.Concrete;

namespace HR.Business.Features.Leaves.Commands.Employee.Create;
public class CreateLeaveCommandHandler(HrDbContext dbContext, IMapper mapper) :
    IRequestHandler<CreateLeaveCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
    {
        var leave = mapper.Map<Leave>(request.Model);

        leave.ApprovalStatus = ApprovalStatus.Pending;
        leave.RequestDate = DateTime.Now;
        leave.CreatorEmployeeId = request.EmployeeId;
        leave.NumberOfDays = (int)(leave.EndDate - leave.StartDate).TotalDays;

        await dbContext.Leaves.AddAsync(leave, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
