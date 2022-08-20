using Arch.Core.Authentication;
using Arch.Core.Authentication.Impl;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Arch.Core.Runtime.Impl
{
    public class RunTimeService : IRunTimeService
    {
        #region ctor

        private readonly HttpContext _context;
        private readonly IComponentContext _componentContext;
        private readonly ITokenProvider _tokenProvider;

        public RunTimeService(IHttpContextAccessor accessor, IComponentContext componentContext, ITokenProvider tokenProvider)
        {
            _componentContext = componentContext;
            _tokenProvider = tokenProvider;
            _context = accessor.HttpContext;
        }

        #endregion

        public string BrowserInfo => _context?.Request?.Headers?["User-Agent"];
        public string IpAddress => _context?.Connection?.RemoteIpAddress?.ToString();
        public string ApplicationDomain => $"{_context?.Request?.Host.Host}:{_context?.Request?.Host.Port}";
        public string UserLanguage => _context?.Request?.Headers?["Accept-Language"] ?? default;

        public ITokenUser User => GetTokenUser();
        public TService Resolve<TService>() => _context.RequestServices.GetService<TService>();
        public TService ResolveComponent<TService>() => _componentContext.Resolve<TService>();
        public ITokenUser GetUserWithQueryString(string field = "access_token") => GetTokenUser(_tokenProvider.Validate(_context.Request.Query[field]) as JwtSecurityToken);
        public ITokenUser GetUserCustomToken(string token) => GetTokenUser(_tokenProvider.Validate(token) as JwtSecurityToken);

        private ITokenUser GetTokenUser(JwtSecurityToken customToken = null)
        {
            if (_context != null)
            {
                var uniqueName = customToken?.Id ?? _context.User.Identity.Name;
                var jti = (customToken?.Claims ?? _context.User.Claims).FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                var audience = (customToken?.Claims ?? _context.User.Claims).FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value;

                if (!string.IsNullOrEmpty(uniqueName) && int.TryParse(jti, out var id))
                    return new TokenUser(id, jti, audience, uniqueName);
            }

            return new TokenUser(0, null, null, null);
        }
    }
}
