using Arch.Core.Runtime;
using Newtonsoft.Json;

namespace Arch.Core.Entity.Audit.Primitive
{
    public interface IModificationAudited : IHasModificationTime
    {
        [JsonIgnore] long? LastModifierUserId { get; }

        void ModificationAuditing(IRunTimeService runTimeService, long? lastModifierUserId = null);
        void ModificationAuditing(long? lastModifierUserId);
    }
}
