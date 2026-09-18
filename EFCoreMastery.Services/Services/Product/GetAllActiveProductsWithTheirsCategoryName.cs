using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Product
{
    public class GetAllActiveProductsWithTheirsCategoryName(AppDbContext context) : IGetAllActiveProductsWithTheirsCategoryNameService
    {
        public async Task<List<ProductDetailListDto>> GetAllActiveProductsWithTheirsCategoryNameAsync()
        {
            return await context.Products.AsNoTracking().Where(p => p.StockQuantity > 0).Select(p => new ProductDetailListDto
            {
                ProductId = p.Id,
                ProductName = p.Name,
                UnitPrice = p.UnitPrice,
                StockQuantity = p.StockQuantity,
                CategoryName = p.Category.Name
            }).ToListAsync();
        }
    }
}
