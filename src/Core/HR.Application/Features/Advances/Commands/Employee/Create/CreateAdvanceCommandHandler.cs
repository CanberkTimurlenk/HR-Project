using AutoMapper;
using MediatR;
using HR.Schema.Response;

namespace HR.Application.Features.Advances.Commands.Employee.Create;
public class CreateAdvanceCommandHandler(HrDbContext dbContext, IMapper mapper) :
    IRequestHandler<CreateAdvanceCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse> Handle(CreateAdvanceCommand request, CancellationToken cancellationToken)
    {
        //var advance = mapper.Map<Advance>(request.Model);

        //var salary = await dbContext.Employees.Where(u => u.Id == request.EmployeeId).Select(e => e.Salary).FirstOrDefaultAsync(cancellationToken);

        //if (advance.Amount > salary * 3)
        //    return new ApiResponse("You can not request more than 3 times your salary");

        //advance.ApprovalStatus = ApprovalStatus.Pending;
        //advance.RequestDate = DateTime.Now;
        //advance.CreatorEmployeeId = request.EmployeeId;

        //await dbContext.Advances.AddAsync(advance, cancellationToken);
        //await dbContext.SaveChangesAsync(cancellationToken);

        //return new ApiResponse();
        return null;
    }
}
