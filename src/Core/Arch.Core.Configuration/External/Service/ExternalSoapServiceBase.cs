namespace Arch.Core.Configuration.External.Service
{
    public class ExternalSoapServiceBase : ExternalServiceBase
    {
        protected ExternalSoapServiceBase(IConfigurationManager configurationManager, string configurationName = null)
            : base(configurationManager, configurationName)
        {
        }
    }
}
