namespace HR.Business.Features.Authentication.Query;

public class AuthenticateUserQueryResponse
{
    public string Id { get; set; }
    public DateTime ExpireDate { get; set; }
    public string Token { get; set; }
    public string Email { get; set; }
}