using Arch.Core.Authentication;

namespace Arch.Core.Runtime
{
    public interface IRunTimeService : IClient
    {
        ITokenUser User { get; }
        string ApplicationDomain { get; }
        string UserLanguage { get; }

        TService Resolve<TService>();
        TService ResolveComponent<TService>();
        ITokenUser GetUserWithQueryString(string field = "access_token");
        ITokenUser GetUserCustomToken(string token);
    }
}
