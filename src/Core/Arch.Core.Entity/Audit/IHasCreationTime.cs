using System.Text.Json.Serialization;

namespace Arch.Core.Entity.Audit
{
    public interface IHasCreationTime
    {
        [JsonIgnore] DateTime CreationTime { get; }
    }
}
