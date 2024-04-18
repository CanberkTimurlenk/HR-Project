using HR.Base.Response;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Advances.Queries.GetByParameter;

public record GetAdvancesByParameterQuery(int? EmployeeId, int UserId, string Role) : IRequest<ApiResponse<IEnumerable<AdvanceResponse>>>;