using AutoMapper;
using HR.Application.Contracts.Repositories.Advances;
using HR.Domain.Entities.Concrete;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.Manager.GetByParameter;

public class GetAdvancesByParameterQueryHandler(IAdvanceRepository advanceRepository, IMapper mapper)
    : IRequestHandler<GetAdvancesByParameterQuery, ApiResponse<IEnumerable<AdvanceResponse>>>
{
    private readonly IAdvanceRepository advanceRepository = advanceRepository;
    private readonly IMapper mapper = mapper;
    public async Task<ApiResponse<IEnumerable<AdvanceResponse>>> Handle(GetAdvancesByParameterQuery request, CancellationToken cancellationToken)
    {

        if (request.EmployeeId != null)
            query = query.Where(x => x.CreatorEmployeeId == request.EmployeeId);

        var leaves = await query.ToListAsync(cancellationToken: cancellationToken);

        var response = mapper.Map<IEnumerable<AdvanceResponse>>(leaves);

        return new ApiResponse<IEnumerable<AdvanceResponse>>(data: response);
    }
}
