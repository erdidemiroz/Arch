namespace Arch.Core.Configuration.External
{
    public class ExternalDatabaseConfiguration : IExternalDatabaseConfiguration
    {
        public string FullName { get; set; }
        public string ConnectionString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
