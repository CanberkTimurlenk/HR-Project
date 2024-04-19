using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.Employee.GetByParameter;

/// <summary>
/// Query to get advances by parameters.
/// </summary>
/// <param name="EmployeeId">The ID of the employee whose advances to retrieve.</param>
/// <param name="UserId">The ID of the user creating the query.</param>
public record GetAdvancesByParameterQuery(int? EmployeeId, int UserId) : IRequest<ApiResponse<IEnumerable<AdvanceResponse>>>;