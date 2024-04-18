using HR.Data.Entities;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Queries.GetByParameter;

public record GetUserByParameterQuery(string? Role) : IRequest<ApiResponse<IEnumerable<UserResponse>>>;