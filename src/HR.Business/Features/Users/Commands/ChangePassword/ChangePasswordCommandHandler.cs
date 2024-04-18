using HR.Api.Helpers;
using HR.Base.Response;
using HR.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Users.Commands.ChangePassword;
public class ChangePasswordCommandHandler(HrDbContext dbContext)
    : IRequestHandler<ChangePasswordCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    public async Task<ApiResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        //var user = await dbContext.Users
        //    .SingleOrDefaultAsync(u => u.ResetPassword.Equals(request.ResetPasswordGuid.Trim()),
        //        cancellationToken: cancellationToken);

        //if (user == null)
        //    return new ApiResponse("Not Found!");

        //user.Password = Md5Extension.GetHash(request.Password);
        //user.IsActive = true;

        //await dbContext.SaveChangesAsync(cancellationToken);
        //return new ApiResponse();

        return null;

    }
}
