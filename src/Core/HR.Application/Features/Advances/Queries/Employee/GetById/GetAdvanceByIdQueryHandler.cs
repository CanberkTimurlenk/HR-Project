using AutoMapper;
using HR.Application.Contracts.Repositories.Advances;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.GetById;

public class GetAdvanceByIdQueryHandler(IAdvanceRepository advanceRepository, IMapper mapper)
    : IRequestHandler<GetAdvanceByIdQuery, ApiResponse<AdvanceResponse>>
{
    private readonly IAdvanceRepository advanceRepository = advanceRepository;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<AdvanceResponse>> Handle(GetAdvanceByIdQuery request, CancellationToken cancellationToken)
    {
        var leave = await advanceRepository.GetAsync(a => a.Id.Equals(request.AdvanceId), cancellationToken: cancellationToken);

        if (leave?.CreatorEmployeeId != request.EmployeeId)
            return new ApiResponse<AdvanceResponse>("You have not access to this advance");

        var response = mapper.Map<AdvanceResponse>(leave);
        return new ApiResponse<AdvanceResponse>(response);
    }
}