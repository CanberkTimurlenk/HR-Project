using AutoMapper;
using HR.Data.Contexts;
using HR.Domain.Entities.Concrete;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.Leaves.Queries.GetByParameter;

public class GetLeavesByParameterQueryHandler(HrDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetLeavesByParameterQuery, ApiResponse<IEnumerable<LeaveResponse>>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;
    public async Task<ApiResponse<IEnumerable<LeaveResponse>>> Handle(GetLeavesByParameterQuery request, CancellationToken cancellationToken)
    {
        if (request.Role == "employee" && request.UserId != request.EmployeeId)
            return new ApiResponse<IEnumerable<LeaveResponse>>("You have not access to leaves");

        IQueryable<Leave> query = dbContext.Leaves.Include(l => l.CreatorEmployee);

        if (request.EmployeeId != null)
            query = query.Where(x => x.CreatorEmployeeId == request.EmployeeId);

        var leaves = await query.ToListAsync(cancellationToken: cancellationToken);
        var response = mapper.Map<IEnumerable<LeaveResponse>>(leaves);

        return new ApiResponse<IEnumerable<LeaveResponse>>(data: response);
    }
}
