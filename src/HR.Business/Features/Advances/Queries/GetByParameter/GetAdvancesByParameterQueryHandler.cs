using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Entities.Concrete;
using HR.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Advances.Queries.GetByParameter;

public class GetAdvancesByParameterQueryHandler(HrDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetAdvancesByParameterQuery, ApiResponse<IEnumerable<AdvanceResponse>>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;
    public async Task<ApiResponse<IEnumerable<AdvanceResponse>>> Handle(GetAdvancesByParameterQuery request, CancellationToken cancellationToken)
    {
        if (request.Role == "employee" && request.UserId != request.EmployeeId)
            return new ApiResponse<IEnumerable<AdvanceResponse>>("You have not access to advances");


        IQueryable<Advance> query = dbContext.Advances.Include(a => a.CreatorEmployee);


        if (request.EmployeeId != null)
            query = query.Where(x => x.CreatorEmployeeId == request.EmployeeId);

        var leaves = await query.ToListAsync(cancellationToken: cancellationToken);

        var response = mapper.Map<IEnumerable<AdvanceResponse>>(leaves);

        return new ApiResponse<IEnumerable<AdvanceResponse>>(data: response);
    }
}
