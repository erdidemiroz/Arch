namespace Arch.Core.Configuration.External.Service
{
    public class ExternalRestServiceBase : ExternalServiceBase
    {
        private readonly HttpClient _client;

        public ExternalRestServiceBase(IConfigurationManager configurationManager, HttpClient client, string configurationName = null)
            : base(configurationManager, configurationName)
        {
            _client = client;
            _client.BaseAddress = new Uri(Configuration?.BaseUrl);
        }
    }
}
