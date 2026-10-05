using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetPagedProductsWithSortingService
    {
        Task<PagedResultDto<ProductListDto>> GetPagedProductsWithSortingAsync(int pageNumber = 1, int pageSize = 10, string? sortBy = "id", bool isDescending = false);
    }
}
