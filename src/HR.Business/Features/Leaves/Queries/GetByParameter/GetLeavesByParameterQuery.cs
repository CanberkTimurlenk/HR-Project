using HR.Base.Response;
using HR.Schema;
using MediatR;

namespace HR.Business.Features.Leaves.Queries.GetByParameter;

public record GetLeavesByParameterQuery(int? EmployeeId, int UserId, string Role) : IRequest<ApiResponse<IEnumerable<LeaveResponse>>>;