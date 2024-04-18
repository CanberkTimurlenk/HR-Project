using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Commands.Delete;

public record DeleteUserCommand(int Id) : IRequest<ApiResponse>;