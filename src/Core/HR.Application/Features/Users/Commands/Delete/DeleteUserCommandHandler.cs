using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler(HrDbContext dbContext) : IRequestHandler<DeleteUserCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        //var user = await dbContext.Users.FindAsync([request.Id], cancellationToken);

        //if (user == null)
        //    return new ApiResponse("Not Found!");

        //user.IsActive = false;
        //await dbContext.SaveChangesAsync(cancellationToken);

        //return new ApiResponse();
        return null;
    }
}
