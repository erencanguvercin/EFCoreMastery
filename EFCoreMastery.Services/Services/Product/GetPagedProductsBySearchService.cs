using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Extensions;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Product
{
    public class GetPagedProductsBySearchService(AppDbContext context) : IGetPagedProductsBySearchService 
    {
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductsBySearchAsync(int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
        {
            var query = context.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p=>EF.Functions.ILike(p.Name,$"%{searchTerm}%"));
            }

            return await query.OrderBy(p=>p.Id).ToPagedResultAsync(pageNumber, pageSize, p => new ProductListDto { Id = p.Id, Name = p.Name, StockQuantity = p.StockQuantity, UnitPrice = p.UnitPrice });
        }
    }
}
