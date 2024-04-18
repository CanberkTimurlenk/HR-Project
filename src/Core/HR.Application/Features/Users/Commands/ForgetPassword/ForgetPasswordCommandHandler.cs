using HR.Api.Helpers;
using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace HR.Application.Features.Users.Commands.ForgetPassword;

public class ForgetPasswordCommandHandler(HrDbContext dbContext, IConfiguration configuration) : IRequestHandler<ForgetPasswordCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IConfiguration configuration = configuration;
    public async Task<ApiResponse> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        //var user = dbContext.Users.FirstOrDefault(u => u.Email == request.Email);

        //if (user == null)
        //    return new ApiResponse("Not Found!");

        //var guid = Guid.NewGuid().ToString();

        //await MailSender.SendAsync(user.Email, "HR System - Reset Your Password!",
        //       $"You can click the link link:/{guid} ", configuration);

        //user.ResetPassword = guid;
        //await dbContext.SaveChangesAsync(cancellationToken);

        //return new ApiResponse();
        return null;
    }
}
