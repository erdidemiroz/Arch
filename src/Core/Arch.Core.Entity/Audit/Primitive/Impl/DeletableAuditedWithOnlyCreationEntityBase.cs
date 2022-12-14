using Arch.Core.Runtime;

namespace Arch.Core.Entity.Audit.Primitive.Impl
{
    [Serializable]
    public abstract class DeletableAuditedWithOnlyCreationEntityBase<TPrimaryKey> : CreationAuditedEntityBase<TPrimaryKey>, IDeletionAudited
    {
        public virtual bool IsDeleted { get; private set; }
        public virtual DateTime? DeletionTime { get; private set; }
        public virtual long? DeleterUserId { get; private set; }

        public void DeletionAuditing(IRunTimeService runTimeService)
        {
            DeletionTime = DateTime.UtcNow;
            DeleterUserId = runTimeService.User.Id;
            IsDeleted = true;
        }
    }
}
