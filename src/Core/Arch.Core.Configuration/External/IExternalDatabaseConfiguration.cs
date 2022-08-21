namespace Arch.Core.Configuration.External
{
    public interface IExternalDatabaseConfiguration : IListConfiguration
    {
        string ConnectionString { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
