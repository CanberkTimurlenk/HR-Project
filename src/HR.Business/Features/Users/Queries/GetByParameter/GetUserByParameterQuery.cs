using HR.Base.Response;
using HR.Data.Entities;
using HR.Schema;
using MediatR;

namespace HR.Business.Users.Queries.GetByParameter;

public record GetUserByParameterQuery(string? Role) : IRequest<ApiResponse<IEnumerable<UserResponse>>>;