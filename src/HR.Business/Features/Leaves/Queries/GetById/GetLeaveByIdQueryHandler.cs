using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Leaves.Queries.GetById;

public class GetLeaveByIdQueryHandler(HrDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetLeaveByIdQuery, ApiResponse<LeaveResponse>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<LeaveResponse>> Handle(GetLeaveByIdQuery request, CancellationToken cancellationToken)
    {
        var leave = await dbContext.Leaves.Include(l => l.CreatorEmployee)
            .SingleOrDefaultAsync(l => l.Id == request.LeaveId, cancellationToken: cancellationToken);

        if (leave?.CreatorEmployeeId != request.EmployeeId)
            return new ApiResponse<LeaveResponse>("You have not access to this leave");

        var response = mapper.Map<LeaveResponse>(leave);

        return new ApiResponse<LeaveResponse>(response);
    }
}
