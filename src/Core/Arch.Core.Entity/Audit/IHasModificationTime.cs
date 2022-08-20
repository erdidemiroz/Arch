using System.Text.Json.Serialization;

namespace Arch.Core.Entity.Audit
{
    public interface IHasModificationTime
    {
        [JsonIgnore] DateTime? LastModificationTime { get; }
    }
}
