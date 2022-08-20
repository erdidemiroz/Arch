namespace Arch.Core.Entity.Audit.Primitive.Impl
{
    [Serializable]
    public abstract class AuditedPassivableEntityBase<TPrimaryKey> : ModificationAuditedEntityBase<TPrimaryKey>, IPassivable
    {
        public virtual bool IsActive { get; protected set; } = true;

        public virtual void IsActiveAuditing(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
