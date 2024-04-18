using HR.Api.Helpers;
using HR.Base;
using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HR.Application.Features.Authentication.Query;

public class AuthenticateUserQueryHandler(HrDbContext dbContext, IConfiguration configuration) : IRequestHandler<AuthenticateUserQuery, ApiResponse<AuthenticateUserQueryResponse>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IConfiguration configuration = configuration;
    public async Task<ApiResponse<AuthenticateUserQueryResponse>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
    {
        /*
        var hashed = Md5Extension.GetHash(request.Password);

        var user = dbContext.Users.AsNoTracking().FirstOrDefault(m => m.Email == request.Email && m.Password == hashed);


        // invalid username or password

        if (user == null)
            return new ApiResponse<AuthenticateUserQueryResponse>("Invalid username or password");

        JwtConfig jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();

        string token = TokenHelper.CreateAccessToken(user, jwtConfig);

        return new ApiResponse<AuthenticateUserQueryResponse>(new AuthenticateUserQueryResponse
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            Token = token,
            ExpireDate = DateTime.Now.AddMinutes(20)
        });
        */

        return null;
    }
}
