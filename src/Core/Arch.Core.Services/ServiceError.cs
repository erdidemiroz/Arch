namespace Arch.Core.Services
{
    public class ServiceError : IServiceError
    {
        public string Code { get; }
        public string Description { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public ServiceError(string code, string description, Exception exception = null, string message = null)
        {
            Code = code;
            Description = description;
            Exception = exception;
            Message = message;
        }
    }
}
