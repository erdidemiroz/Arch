namespace Arch.Core
{
    public interface IEntity
    {
    }

    public interface IEntity<out TPrimaryKey> : IEntity
    {
        TPrimaryKey Id { get; }
    }
}
