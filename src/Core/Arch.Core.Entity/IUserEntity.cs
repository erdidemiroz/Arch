using System.Text.Json.Serialization;

namespace Arch.Core.Entity
{
    public interface IUserEntity : IUserEntity<int>
    {
    }

    public interface IUserEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        string FullName { get; }
        string MailAddress { get; }
        [JsonIgnore] byte[] Password { get; }
    }
}
