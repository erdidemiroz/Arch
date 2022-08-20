using Arch.Core.Runtime;

namespace Arch.Core.Entity.Audit.Primitive.Impl
{
    [Serializable]
    public abstract class ModificationAuditedEntityBase<TPrimaryKey> : CreationAuditedEntityBase<TPrimaryKey>, IModificationAudited
    {
        public virtual DateTime? LastModificationTime { get; private set; }
        public virtual long? LastModifierUserId { get; private set; }

        public void ModificationAuditing(IRunTimeService runTimeService, long? lastModifierUserId = null)
        {
            LastModificationTime = DateTime.UtcNow;
            LastModifierUserId = lastModifierUserId.HasValue ? lastModifierUserId : runTimeService.User?.Id != 0 ? runTimeService.User?.Id : null;
        }

        public void ModificationAuditing(long? lastModifierUserId)
        {
            LastModificationTime = DateTime.UtcNow;
            LastModifierUserId = lastModifierUserId;
        }
    }
}
