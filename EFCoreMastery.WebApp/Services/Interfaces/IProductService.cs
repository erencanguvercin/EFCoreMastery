using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.Features.Products.Queries.GetPagedProductsWithFilter;

namespace EFCoreMastery.WebApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<PagedResultDto<GetPagedProductsWithFilterQueryResponse>> GetPagedProductsWithFilterAsync(GetPagedProductsWithFilterQueryRequest request);
    }
}
