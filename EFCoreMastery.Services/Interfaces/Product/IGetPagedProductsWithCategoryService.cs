using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetPagedProductsWithCategoryService
    {
        Task<PagedResultDto<ProductListDto>> GetPagedProductsWithCategoryAsync(int pageNumber = 1, int pageSize = 10, string? sortBy = "id", bool isDescending = false, int? categoryId = null);
    }
}
