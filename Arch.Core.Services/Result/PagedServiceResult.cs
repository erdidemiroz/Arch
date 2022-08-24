using System.Collections;

namespace Arch.Core.Services.Result
{
    public class PagedServiceResult<TResult> : ServiceResultBase<TResult>, IPagedServiceResult<TResult> where TResult : IEnumerable
    {
        public int PageIndex { get; }
        public long RowCount { get; }

        public PagedServiceResult(TResult result, int pageIndex, long rowCount)
        {
            Result = result;
            PageIndex = pageIndex;
            RowCount = rowCount;
        }
    }
}
