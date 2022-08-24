using System.Collections;

namespace Arch.Core.Services.Result
{
    public interface IServiceResult
    {
        int Code { get; }
        bool IsSuccess { get; }
        List<IServiceError> Errors { get; }
    }

    public interface IServiceResult<TResult> : IServiceResult
    {
        TResult Result { get; set; }
    }

    public interface IPagedServiceResult<TResult> : IServiceResult<TResult> where TResult : IEnumerable
    {
        int PageIndex { get; }
        long RowCount { get; }
    }
}