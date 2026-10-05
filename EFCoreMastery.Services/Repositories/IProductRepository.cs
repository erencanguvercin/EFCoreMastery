using EFCoreMastery.Domain.Entities;

namespace EFCoreMastery.Services.Repositories
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<Product?> GetProductBySkuAsync(string sku, CancellationToken cancellationToken = default);
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default);
    }
}
