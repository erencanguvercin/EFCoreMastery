using EFCoreMastery.Domain.Entities;
using EFCoreMastery.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Persistence.Repositories
{
    public class ProductRepository(AppDbContext context) : EfBaseRepository<Product, AppDbContext>(context), IProductRepository
    {
        public async Task<Product?> GetProductBySkuAsync(string sku, CancellationToken cancellationToken = default)
        {
            return await GetOneAsync(p => p.SKU == sku && !p.IsDeleted, cancellationToken);
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            return await GetAsQueryableNoTracking().Where(p => p.CategoryId == categoryId && !p.IsDeleted).ToListAsync(cancellationToken);
        }
    }
}
