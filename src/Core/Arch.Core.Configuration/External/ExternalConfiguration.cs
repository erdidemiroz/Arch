namespace Arch.Core.Configuration.External
{
    public class ExternalConfiguration : IExternalConfiguration
    {
        public string FullName { get; set; }
        public string BaseUrl { get; }
    }
}
