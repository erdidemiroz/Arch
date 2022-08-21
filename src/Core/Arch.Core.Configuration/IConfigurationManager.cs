using Arch.Core.Configuration.External;
using Arch.Core.Configuration.File;

namespace Arch.Core.Configuration
{
    public interface IConfigurationManager
    {
        string ApplicationName { get; set; }
        EnvironmentConfig Environment { get; }
        List<ExternalConfiguration> ExternalServices { get; }
        List<ExternalDatabaseConfiguration> ExternalDatabases { get; }
    }
}
