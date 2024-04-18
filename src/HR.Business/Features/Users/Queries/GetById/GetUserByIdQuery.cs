using HR.Base.Response;
using HR.Data.Entities;
using HR.Schema;
using MediatR;

namespace HR.Business.Users.Queries.GetByParameter;

public record GetUserByIdQuery(int Id) : IRequest<ApiResponse<UserResponse>>;