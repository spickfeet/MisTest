using Microsoft.EntityFrameworkCore;
using MisTest.Common.Page;

namespace MisTest.Infrastructure.Extensions
{
    public static class ToPageExtension
    {
        public static async Task<PagedResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageParams? pageParams)
        {
            pageParams ??= new();
            int pageNumber = Math.Max(1, pageParams.PageNumber ?? 1);
            int pageSize = Math.Min(Math.Max(1, pageParams.PageSize ?? 10), 20);

            int totalCount = await query.CountAsync();

            if (totalCount == 0)
            {
                return new PagedResult<T>(new List<T>(), pageSize, 1, totalCount);
            }

            List<T> data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<T>(data, pageSize, pageNumber, totalCount);
        }
    }
}
