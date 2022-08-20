using System.Text.Json.Serialization;
using Arch.Core.Runtime;

namespace Arch.Core.Entity.Audit.Primitive
{
    public interface ICreationAudited : IHasCreationTime
    {
        [JsonIgnore] long? CreatorUserId { get; }

        void CreationAuditing(IRunTimeService runTimeService, long? creatorUserId = null);
        void CreationAuditing(long? creatorUserId);
    }
}
