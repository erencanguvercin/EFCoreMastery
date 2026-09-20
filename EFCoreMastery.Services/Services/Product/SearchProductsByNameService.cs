using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Product
{
    public class SearchProductsByNameService(AppDbContext context) : ISearchProductsByNameService
    {
        public async Task<List<ProductListDto>> SearchProductsByNameAsync(string? searchName)
        {
            var query = context.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(p => p.Name.Contains(searchName));
            }

            return await query.Select(p => new ProductListDto
            {
                Id=p.Id,
                Name=p.Name,
                StockQuantity=p.StockQuantity,
                UnitPrice=p.UnitPrice
            }).ToListAsync();
        }
    }
}
