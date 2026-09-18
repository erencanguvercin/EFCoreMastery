using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Category;
using EFCoreMastery.Services.Interfaces.Category;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Category
{
    public class GetCategoryReportService(AppDbContext context) : IGetCategoryReportService
    {
        public async Task<List<CategoryReportDto>> GetCategoryReportAsync()
        {
            return await context.Categories.AsNoTracking().Select(c => new CategoryReportDto
            {
                CategoryName = c.Name,
                TotalProductCount = c.Products.Count(p=>p.StockQuantity>0),
                AveragePrice = c.Products.Where(p=>p.StockQuantity>0).Average(p=>(decimal?)p.UnitPrice) ?? 0
            }).ToListAsync();
        }
    }
}
