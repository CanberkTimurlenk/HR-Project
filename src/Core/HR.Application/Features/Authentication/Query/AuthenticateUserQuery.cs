using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Authentication.Query;

public record AuthenticateUserQuery(string Email, string Password) : IRequest<ApiResponse<AuthenticateUserQueryResponse>>;