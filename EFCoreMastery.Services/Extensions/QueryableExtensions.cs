using EFCoreMastery.Services.DTOs.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFCoreMastery.Services.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResultDto<TDto>> ToPagedResultAsync<TEntity,TDto>(this IQueryable<TEntity> query, int pageNumber, int pageSize, Expression<Func<TEntity,TDto>> projection) where TEntity: class
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }
            else if (pageSize > 100)
            {
                pageSize = 100;
            }

            var totalCount = await query.CountAsync();
            if(totalCount == 0)
            {
                return new PagedResultDto<TDto>(Array.Empty<TDto>(), pageNumber, pageSize, 0);
            }

            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(projection).ToListAsync();

            return new PagedResultDto<TDto>(items, pageNumber, pageSize, totalCount);
        }
    }
}
