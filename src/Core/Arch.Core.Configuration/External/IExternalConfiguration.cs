namespace Arch.Core.Configuration.External
{
    public interface IExternalConfiguration : IListConfiguration
    {
        string BaseUrl { get; }
    }
}
