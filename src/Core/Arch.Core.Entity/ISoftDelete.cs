using System.Text.Json.Serialization;

namespace Arch.Core.Entity
{
    public interface ISoftDelete
    {
        [JsonIgnore] bool IsDeleted { get; }
    }
}
