using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Product
{
    public class GetAllActiveProductsByCategoryId(AppDbContext context):IGetActiveProductsByCategoryIdService
    {
        public async Task<List<ProductListDto>> GetActiveProductsByCategoryIdAsync(int categoryId)
        {
            return await context.Products.AsNoTracking().Where(p => p.CategoryId == categoryId && p.StockQuantity > 0).Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                StockQuantity = p.StockQuantity,
                UnitPrice = p.UnitPrice
            }).ToListAsync();
        }
    }
}
