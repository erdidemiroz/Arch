using Arch.Core.Runtime;

namespace Arch.Core.Entity.Audit.Primitive.Impl
{
    [Serializable]
    public abstract class CreationAuditedEntityBase<TPrimaryKey> : EntityBase<TPrimaryKey>, ICreationAudited
    {
        public virtual DateTime CreationTime { get; private set; }
        public virtual long? CreatorUserId { get; private set; }

        public void CreationAuditing(IRunTimeService runTimeService, long? creatorUserId = null)
        {
            CreationTime = DateTime.UtcNow;
            CreatorUserId = creatorUserId.HasValue ? creatorUserId : runTimeService.User?.Id != 0 ? runTimeService.User?.Id : null;
        }

        public void CreationAuditing(long? creatorUserId)
        {
            CreationTime = DateTime.UtcNow;
            CreatorUserId = creatorUserId;
        }
    }
}
