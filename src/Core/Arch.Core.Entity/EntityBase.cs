namespace Arch.Core.Entity
{
    public abstract class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; }
    }
}
