using Arch.Core.Configuration.External;
using Arch.Core.Configuration.File;
using Arch.Core.Configuration.Resource;
using Microsoft.Extensions.Configuration;

namespace Arch.Core.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        #region ctor

        public string ApplicationName { get; set; }
        public EnvironmentConfig Environment { get; }
        public List<ExternalConfiguration> ExternalServices { get; }
        public List<ExternalDatabaseConfiguration> ExternalDatabases { get; }
        private readonly IConfigurationRoot _appConfiguration;

        public ConfigurationManager(IConfigurationRoot appConfiguration)
        {
            _appConfiguration = appConfiguration;
            Environment = new EnvironmentConfig();
            ExternalDatabases = new List<ExternalDatabaseConfiguration>();
            ExternalServices = new List<ExternalConfiguration>();
            appConfiguration.Bind(this);
        }

        #endregion

        public ConfigurationManager StorageConfiguration<TConfiguration, TService>() where TConfiguration : EnvironmentConfiguration
        {
            Environment.Storages.Add(GetConfigurationInstance<TConfiguration, TService>("Environment:Storages"));
            return this;
        }

        public ConfigurationManager ExternalServiceConfiguration<TConfiguration, TService>() where TConfiguration : ExternalConfiguration
        {
            ExternalServices.Add(GetConfigurationInstance<TConfiguration, TService>("ExternalServices"));
            return this;
        }

        public ConfigurationManager ExternalDatabaseConfiguration<TConfiguration, TService>() where TConfiguration : ExternalDatabaseConfiguration
        {
            ExternalDatabases.Add(GetConfigurationInstance<TConfiguration, TService>("ExternalDatabases"));
            return this;
        }

        private TConfiguration GetConfigurationInstance<TConfiguration, TService>(string sectionKey) where TConfiguration : IListConfiguration
        {
            var services = _appConfiguration.GetSection(sectionKey).GetChildren();
            var service = services.FirstOrDefault(x => x.GetSection("FullName").Value == typeof(TService).FullName);
            if (service == null)
                throw new ArgumentNullException(string.Format(ConfigurationResource.NotFoundConfigExceptionText, typeof(TService).FullName));
            var configuration = Activator.CreateInstance<TConfiguration>();

            service.Bind(configuration);
            return configuration;
        }
    }
}
