using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Authentication.Query;

public record AuthenticateUserQuery(string Email, string Password) : IRequest<ApiResponse<AuthenticateUserQueryResponse>>;