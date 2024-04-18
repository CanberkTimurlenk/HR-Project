using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Commands.Update;

public record UpdateUserCommand(int Id, string PhotoFile, UpdateUserCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateUserCommandRequest(string PhoneNumber, string Address);