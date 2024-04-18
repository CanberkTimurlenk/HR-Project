using HR.Base.Response;
using MediatR;

namespace HR.Business.Users.Commands.ChangePassword;

public record ChangePasswordCommand(string ResetPasswordGuid, string Password) : IRequest<ApiResponse>;