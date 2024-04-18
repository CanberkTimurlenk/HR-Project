using HR.Base.Response;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Advances.Queries.GetById;
public record GetAdvanceByIdQuery(int EmployeeId, int AdvanceId, string Role) : IRequest<ApiResponse<AdvanceResponse>>;