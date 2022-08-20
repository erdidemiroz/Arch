namespace Arch.Core.Runtime
{
    public interface IClient
    {
        string BrowserInfo { get; }
        string IpAddress { get; }
    }
}
