using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace EFCoreMastery.Services.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllActiveAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllActiveAsNoTrackingAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllActiveByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllActiveAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, bool disableTracking = true, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true, CancellationToken cancellationToken = default);

        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<T?> GetActiveByIdAsync(long id, CancellationToken cancellationToken = default);


        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IReadOnlyList<T> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IReadOnlyList<T> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(List<T> entities, CancellationToken cancellationToken = default);


        Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        IQueryable<T> GetAsQueryable();
        IQueryable<T> GetAsQueryableNoTracking();

        Task<List<T>> GetEntitiesAsPaginationAsync(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<List<T>> GetEntitiesAsPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        IQueryable<TResult> Join<TJoin, TKey, TResult>(Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TJoin, TKey>> innerKeySelector, Expression<Func<T, TJoin, TResult>> resultSelector) where TJoin : class;

        IQueryable<TResult> LeftJoin<TJoin, TKey, TResult>(Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TJoin, TKey>> innerKeySelector, Func<T, TJoin?, TResult> resultSelector) where TJoin : class;

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SoftDeleteAsync(long id, string updatedBy, DateTime updatedAt, CancellationToken cancellationToken = default);
    }
}
