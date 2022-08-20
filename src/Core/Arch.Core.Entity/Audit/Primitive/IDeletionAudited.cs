using Arch.Core.Runtime;
using Newtonsoft.Json;

namespace Arch.Core.Entity.Audit.Primitive
{
    public interface IDeletionAudited : IHasDeletionTime
    {
        [JsonIgnore] long? DeleterUserId { get; }

        void DeletionAuditing(IRunTimeService runTimeService);
    }
}
