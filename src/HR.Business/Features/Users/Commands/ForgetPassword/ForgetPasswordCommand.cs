using HR.Base.Response;
using MediatR;

namespace HR.Business.Users.Commands.ForgetPassword;

public record ForgetPasswordCommand(string Email) : IRequest<ApiResponse>;