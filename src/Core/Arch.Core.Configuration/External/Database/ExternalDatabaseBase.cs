namespace Arch.Core.Configuration.External.Database
{
    public abstract class ExternalDatabaseBase : IExternalDatabase
    {
        public IExternalDatabaseConfiguration Configuration { get; }
        protected string ConnectionString => Configuration?.ConnectionString;
        protected string UserName => Configuration?.UserName;
        protected string Password => Configuration?.Password;

        protected ExternalDatabaseBase(IConfigurationManager configurationManager)
        {
            Configuration = configurationManager.ExternalDatabases.FirstOrDefault(x => x.FullName == GetType().FullName);
        }
    }
}
