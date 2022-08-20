using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Arch.Core.Authentication.Impl.Enums;
using System.Text;
using System.Security.Principal;

namespace Arch.Core.Authentication.Impl
{
    public class FileTokenProvider : ITokenProvider
    {
        #region ctor

        private readonly IConfiguration _configuration;

        public FileTokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        private const string Section = "FileTokenProvider";
        public string Issuer => _configuration[$"{Section}:{TokenConfiguration.Issuer}"];
        public string Audience => _configuration[$"{Section}:{TokenConfiguration.Audience}"];
        public DateTime ExpireDate => DateTime.Now.AddSeconds(Convert.ToInt32(_configuration[$"{Section}:{TokenConfiguration.TokenExpire}"]));

        public SymmetricSecurityKey GetSignInKey() => new (Encoding.UTF8.GetBytes(_configuration[$"{Section}:{TokenConfiguration.Secret}"]));

        public SigningCredentials GetSigningCredentials() => new (GetSignInKey(), SecurityAlgorithms.HmacSha256);

        public TokenValidationParameters GetTokenValidationParameters() =>
            new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSignInKey(),
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateAudience = true,
                ValidAudience = Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

        public SecurityToken CreateToken(string unique, string jti, string auidence, string sub = "authorization") =>
            CreateToken(new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, unique),
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim(JwtRegisteredClaimNames.Aud, auidence)
            });

        public SecurityToken CreateToken(IEnumerable<Claim> claims) =>
            new JwtSecurityToken(Issuer,
                Audience,
                claims,
                expires: ExpireDate,
                signingCredentials: GetSigningCredentials());

        public SecurityToken CreateRefreshToken(string unique, string jti, string audience, string sub = "refresh") =>
            CreateRefreshToken(new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, unique),
                new Claim(JwtRegisteredClaimNames.Sub, sub),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim(JwtRegisteredClaimNames.Aud, audience)
            });

        public SecurityToken CreateRefreshToken(IEnumerable<Claim> claims) =>
            new JwtSecurityToken(Issuer, Audience, claims, expires: DateTime.Now.AddSeconds(Convert.ToInt32(_configuration[$"{Section}:{TokenConfiguration.RefreshExpire}"])), signingCredentials: GetSigningCredentials());


        public SecurityToken Validate(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            IPrincipal principal = tokenHandler.ValidateToken(token, GetTokenValidationParameters(), out var validatedToken);
            Thread.CurrentPrincipal = principal;
            return validatedToken;
        }
    }
}
