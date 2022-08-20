using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Arch.Core.Authentication
{
    public interface ITokenProvider
    {
        string Issuer { get; }
        string Audience { get; }
        DateTime ExpireDate { get; }

        SymmetricSecurityKey GetSignInKey();
        SigningCredentials GetSigningCredentials();
        TokenValidationParameters GetTokenValidationParameters();
        SecurityToken CreateToken(string unique, string jti, string auidence, string sub = "authorization");
        SecurityToken CreateToken(IEnumerable<Claim> claims);
        SecurityToken CreateRefreshToken(string unique, string jti, string audience, string sub = "refresh");
        SecurityToken CreateRefreshToken(IEnumerable<Claim> claims);
        SecurityToken Validate(string token);
    }
}
