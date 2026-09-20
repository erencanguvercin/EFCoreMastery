using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface ISearchProductsByNameService
    {
        Task<List<ProductListDto>> SearchProductsByNameAsync(string? searchName);
    }
}
