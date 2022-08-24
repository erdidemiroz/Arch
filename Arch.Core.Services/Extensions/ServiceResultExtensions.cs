using Arch.Core.Services.Result;

namespace Arch.Core.Services.Extensions
{
    public static class ServiceResultExtensions
    {
        public static IEnumerable<TEntity> ToPaged<TEntity>(this IQueryable<TEntity> list, int pageNumber = 0, int itemsPerPage = 20)
        {
            if (pageNumber < 1 || itemsPerPage < 0)
                return list.Skip(pageNumber).Take(itemsPerPage).ToList();
            return list.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public static IEnumerable<TEntity> ToPaged<TEntity>(this IEnumerable<TEntity> list, int pageNumber = 0, int itemsPerPage = 20)
        {
            if (pageNumber < 1 || itemsPerPage < 0)
                return list.Skip(pageNumber).Take(itemsPerPage).ToList();
            return list.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public static IPagedServiceResult<IEnumerable<TAny>> ToPagedServiceResult<TAny>(this IEnumerable<TAny> obj, int pageIndex, long rowCount) => 
            new PagedServiceResult<IEnumerable<TAny>>(obj, pageIndex, rowCount);
    }
}
