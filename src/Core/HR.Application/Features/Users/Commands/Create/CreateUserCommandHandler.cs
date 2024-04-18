using AutoMapper;
using HR.Api.Helpers;
using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace HR.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler(HrDbContext dbContext, IMapper mapper, IConfiguration configuration) : IRequestHandler<CreateUserCommand, ApiResponse<int>>
{
    private readonly IConfiguration configuration = configuration;
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;
    public async Task<ApiResponse<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        /*
        var user = mapper.Map<User>(request.Model);

        var guid = Guid.NewGuid().ToString();

        user.Role = "employee";
        user.Password = Md5Extension.GetHash(guid);
        user.ResetPassword = guid;
        user.IsActive = false;
        user.PhotoFile = request.FileName;

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await MailSender.SendAsync(user.Email, "Welcome to Hr System",
                $"Your password is \"{guid}\" \n for security reasons you need to change your password at your first login", configuration);

        return new ApiResponse<int>(user.Id);
        */
        return null;
    }
}