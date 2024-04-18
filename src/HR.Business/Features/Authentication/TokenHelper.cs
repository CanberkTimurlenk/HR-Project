using HR.Base;
using HR.Data.Entities.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HR.Business.Features.Authentication;
public static class TokenHelper
{
    public static string CreateAccessToken(ApplicationUser user, JwtConfig jwtConfig)
    {
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken); // Access Token        
    }

    private static Claim[] GetClaims(ApplicationUser user)
    {
        return
        [
            new Claim("Id", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Role, user.GetType().Name)
        ];
    }
}