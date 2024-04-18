using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Commands.ChangePassword;

public record ChangePasswordCommand(string ResetPasswordGuid, string Password) : IRequest<ApiResponse>;