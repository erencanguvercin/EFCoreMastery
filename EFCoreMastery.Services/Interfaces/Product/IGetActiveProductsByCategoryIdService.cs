using EFCoreMastery.Services.DTOs.Product;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetActiveProductsByCategoryIdService
    {
        Task<List<ProductListDto>> GetActiveProductsByCategoryIdAsync(int categoryId);
       
    }
}
