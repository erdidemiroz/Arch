namespace Arch.Core.Configuration.External.Service
{
    public abstract class ExternalServiceBase : IExternalService
    {
        protected ExternalServiceBase(IConfigurationManager configurationManager, string configurationName = null)
        {
            if (string.IsNullOrEmpty(configurationName))
                Configuration = configurationManager.ExternalServices.FirstOrDefault(x => x.FullName == GetType().FullName);
            else
                Configuration = configurationManager.ExternalServices.FirstOrDefault(x => x.FullName == configurationName);
            BaseUrl = new Uri(Configuration?.BaseUrl);
        }

        protected Uri BaseUrl { get; }
        public IExternalConfiguration Configuration { get; }
    }
}
