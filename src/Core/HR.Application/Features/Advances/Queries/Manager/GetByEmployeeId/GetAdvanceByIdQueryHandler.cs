using AutoMapper;
using HR.Application.Contracts.Repositories.Advances;
using HR.Application.Contracts.Repositories.Employees;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.Manager.GetByEmployeeId;

public class GetAdvancesByEmployeeIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    : IRequestHandler<GetAdvanceByEmployeeIdQuery, ApiResponse<AdvanceResponse>>
{
    private readonly IEmployeeRepository employeeRepository = employeeRepository;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<AdvanceResponse>> Handle(GetAdvanceByEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        var leave = await employeeRepository.GetAdvancesByEmployeeIdAsync
            .SingleOrDefaultAsync(a => a.Id == request.AdvanceId, cancellationToken: cancellationToken);

        if (leave?.CreatorEmployeeId != request.EmployeeId)
            return new ApiResponse<AdvanceResponse>("You have not access to this advance");

        var response = mapper.Map<AdvanceResponse>(leave);

        return new ApiResponse<AdvanceResponse>(response);
    }
}
