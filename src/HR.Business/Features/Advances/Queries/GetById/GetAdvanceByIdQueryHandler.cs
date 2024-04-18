using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Advances.Queries.GetById;

public class GetAdvanceByIdQueryHandler(HrDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetAdvanceByIdQuery, ApiResponse<AdvanceResponse>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<AdvanceResponse>> Handle(GetAdvanceByIdQuery request, CancellationToken cancellationToken)
    {
        var leave = await dbContext.Advances.Include(a => a.CreatorEmployee)
            .SingleOrDefaultAsync(a => a.Id == request.AdvanceId, cancellationToken: cancellationToken);

        if (leave?.CreatorEmployeeId != request.EmployeeId)
            return new ApiResponse<AdvanceResponse>("You have not access to this advance");

        var response = mapper.Map<AdvanceResponse>(leave);

        return new ApiResponse<AdvanceResponse>(response);
    }
}
