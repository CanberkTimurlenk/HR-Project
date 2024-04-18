using HR.Data.Entities;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Queries.GetById;

public record GetUserByIdQuery(int Id) : IRequest<ApiResponse<UserResponse>>;