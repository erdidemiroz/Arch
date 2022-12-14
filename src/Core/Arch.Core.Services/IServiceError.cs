namespace Arch.Core.Services
{
    public interface IServiceError
    {
        string Code { get; }
        string Description { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}