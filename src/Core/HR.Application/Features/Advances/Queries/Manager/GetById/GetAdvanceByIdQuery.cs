using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.Manager.GetById;
public record GetAdvanceByIdQuery(int AdvanceId) : IRequest<ApiResponse<AdvanceResponse>>;