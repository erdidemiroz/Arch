using System.Text.Json.Serialization;

namespace Arch.Core.Entity.Audit
{
    public interface IHasDeletionTime : ISoftDelete
    {
        [JsonIgnore] DateTime? DeletionTime { get; }
    }
}
