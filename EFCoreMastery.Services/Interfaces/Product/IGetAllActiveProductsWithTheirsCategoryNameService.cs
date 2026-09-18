using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetAllActiveProductsWithTheirsCategoryNameService
    {
        Task<List<ProductDetailListDto>> GetAllActiveProductsWithTheirsCategoryNameAsync();
    }
}
