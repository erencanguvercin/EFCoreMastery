using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Extensions;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFCoreMastery.Services.Services.Product
{
    public class GetPagedProductsWithSortingService(AppDbContext context) : IGetPagedProductsWithSortingService
    {
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductsWithSortingAsync(int pageNumber = 1, int pageSize = 10, string? sortBy = "id", bool isDescending = false)
        {
            var query = context.Products.AsNoTracking();

            Expression<Func<Domain.Entities.Product, object>> keySelector = sortBy?.ToLower() switch
            {
                "name" => p => p.Name,
                "price" or "unitprice" => p => p.UnitPrice,
                "stock" or "stockquantity" => p => p.StockQuantity,
                _ => p => p.Id
            };

            query = isDescending ? query.OrderByDescending(keySelector) : query.OrderBy(keySelector);

            return await query.ToPagedResultAsync(pageNumber, pageSize, p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
                StockQuantity = p.StockQuantity
            });
        }
    }
}
