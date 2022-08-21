using Arch.Core.Configuration.File.Enums;

namespace Arch.Core.Configuration.File
{
    public class EnvironmentConfig
    {
        public ICollection<EnvironmentConfiguration> Storages { get; }
        public string UrlBase { get; set; }
        public string BaseDomain { get; set; }
        public StorageType DefaultStorage { get; set; }

        public EnvironmentConfig()
        {
            Storages = new List<EnvironmentConfiguration>();
        }
    }
}
