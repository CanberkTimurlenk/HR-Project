using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Commands.ForgetPassword;

public record ForgetPasswordCommand(string Email) : IRequest<ApiResponse>;