using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Users.Commands.ResetPassword;

public record ResetPasswordCommand(string NewPassword) : IRequest<ApiResponse>;