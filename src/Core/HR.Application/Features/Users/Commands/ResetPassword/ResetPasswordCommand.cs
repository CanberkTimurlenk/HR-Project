using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Commands.ResetPassword;

public record ResetPasswordCommand(string NewPassword) : IRequest<ApiResponse>;