using HR.Base.Response;
using MediatR;

namespace HR.Business.Users.Commands.Delete;

public record DeleteUserCommand(int Id) : IRequest<ApiResponse>;