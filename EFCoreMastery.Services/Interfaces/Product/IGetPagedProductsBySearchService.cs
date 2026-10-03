using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetPagedProductsBySearchService
    {
        Task<PagedResultDto<ProductListDto>> GetPagedProductsBySearchAsync(int pageNumber = 1, int pageSize = 10, string? searchTerm = null);
    }
}
