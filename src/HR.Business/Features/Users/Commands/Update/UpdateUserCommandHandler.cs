using HR.Base.Response;
using HR.Data.Contexts;
using MediatR;

namespace HR.Business.Users.Commands.Update;

public class UpdateUserCommandHandler(HrDbContext dbContext)
    : IRequestHandler<UpdateUserCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        //var user = await dbContext.Users.FindAsync([request.Id], cancellationToken);

        //if (user == null)
        //    return new ApiResponse("Not Found!");

        //user.PhoneNumber = request.Model.PhoneNumber;
        //user.PhotoFile = request.PhotoFile;
        //user.Address = request.Model.Address;

        //await dbContext.SaveChangesAsync(cancellationToken);

        //return new ApiResponse();

        return null;

    }
}
