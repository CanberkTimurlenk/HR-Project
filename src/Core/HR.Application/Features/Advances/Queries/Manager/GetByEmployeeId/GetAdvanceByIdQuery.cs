using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.Manager.GetByEmployeeId;
public record GetAdvanceByEmployeeIdQuery(int EmployeeId) : IRequest<ApiResponse<AdvanceResponse>>;