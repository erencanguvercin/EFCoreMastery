using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;
using EFCoreMastery.Services.Extensions;
using EFCoreMastery.Services.Interfaces.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Product
{
    public class GetPagedProductsService(AppDbContext context) : IGetPagedProductsService
    {
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductsAsync(int pageNumber = 1, int pageSize = 10)
        {

            if(pageNumber<1)
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

            var query = context.Products.AsNoTracking();

            return await query.OrderBy(p=>p.Id).ToPagedResultAsync(pageNumber, pageSize, p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                StockQuantity = p.StockQuantity,
                UnitPrice = p.UnitPrice
            });
            
        }
    }
}
