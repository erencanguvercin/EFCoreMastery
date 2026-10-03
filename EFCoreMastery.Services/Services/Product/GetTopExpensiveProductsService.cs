using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Product
{
    public class GetTopExpensiveProductsService(AppDbContext context) : IGetTopExpensiveProductsService
    {
        public async Task<List<ProductListDto>> GetTopExpensiveProductsAsync(int count = 3)
        {
            return await context.Products.AsNoTracking().Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                StockQuantity = p.StockQuantity,
                UnitPrice = p.UnitPrice
            }).OrderByDescending(p => p.UnitPrice).Take(count).ToListAsync();
        }
    }
}
