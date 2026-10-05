using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.Features.Products.Queries.GetPagedProductsWithFilter;
using EFCoreMastery.Services.Results.Concretes;
using EFCoreMastery.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace EFCoreMastery.WebApp.Services
{
    public class ProductService(HttpClient httpClient) : IProductService
    {
        public async Task<PagedResultDto<GetPagedProductsWithFilterQueryResponse>> GetPagedProductsWithFilterAsync(GetPagedProductsWithFilterQueryRequest request)
        {
            // 1. Request nesnesindeki parametreleri Dictionary'ye çevirip URL'ye dinamik ekleme

            var queryParams = new Dictionary<string,string?>
            {
                ["pageNumber"] = request.PageNumber.ToString(),
                ["pageSize"] = request.PageSize.ToString(),
                ["sortBy"] = request.SortBy ?? string.Empty,
                ["isDescending"] = request.IsDescending.ToString(),
                ["searchTerm"] = request.SearchTerm ?? string.Empty,
                ["minPrice"] = request.MinPrice?.ToString() ?? string.Empty,
                ["maxPrice"] = request.MaxPrice?.ToString() ?? string.Empty,
                ["categoryId"] = request.CategoryId?.ToString() ?? string.Empty
            };

            // 2. AddQueryString: Null olan alanları otomatik eler, özel karakterleri URL-Encode eder.

            var url = QueryHelpers.AddQueryString("api/v1/products", queryParams);

            // 3. HTTP GET çağrısı ve zarfı extract etme

            var result = await httpClient.GetFromJsonAsync<TypedSuccessResult<PagedResultDto<GetPagedProductsWithFilterQueryResponse>>>(url);

            return result?.Data ?? new PagedResultDto<GetPagedProductsWithFilterQueryResponse>();
        }
    }
}
