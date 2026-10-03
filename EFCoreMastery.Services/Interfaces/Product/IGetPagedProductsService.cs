using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetPagedProductsService
    {
        Task<PagedResultDto<ProductListDto>> GetPagedProductsAsync(int pageNumber = 1, int pageSize = 10);
    }
}
