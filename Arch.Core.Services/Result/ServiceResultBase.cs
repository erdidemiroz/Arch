namespace Arch.Core.Services.Result
{
    public class ServiceResultBase<TResult> : IServiceResult<TResult>
    {
        public int Code { get; set; }
        public bool IsSuccess => !Errors.Any();
        public List<IServiceError> Errors { get; set; }
        public TResult Result { get; set; }

        public ServiceResultBase()
        {
            Errors = new List<IServiceError>();
        }
    }
}
