using EFCoreMastery.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace EFCoreMastery.Persistence.Repositories
{
    public class EfBaseRepository<T, TContext>(TContext context) : IBaseRepository<T> where T : class where TContext : DbContext
    {
        protected readonly TContext Context = context;
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<T>().AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task AddRangeAsync(IReadOnlyList<T> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<T>().AddRangeAsync(entities, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AnyAsync(predicate, cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().CountAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().RemoveRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> GetActiveByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(p => EF.Property<long>(p, "Id") == id && !EF.Property<bool>(p, "IsDeleted"), cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllActiveAsNoTrackingAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().Where(p => !EF.Property<bool>(p, "IsDeleted")).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().Where(p => !EF.Property<bool>(p, "IsDeleted")).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllActiveAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().Where(p => !EF.Property<bool>(p, "IsDeleted")).Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllActiveByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().Where(p => EF.Property<string>(p, "Id") == id && !EF.Property<bool>(p, "IsDeleted")).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public IQueryable<T> GetAsQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetAsQueryableNoTracking()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null, bool disableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = Context.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (!string.IsNullOrWhiteSpace(includeString))
            {
                query = query.Include(includeString);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = Context.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (includes != null && includes.Count > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FindAsync([id], cancellationToken);
        }

        public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FindAsync([id], cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FindAsync([id], cancellationToken);
        }

        public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FindAsync([id], cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            int validPageNumber = pageNumber < 1 ? 1 : pageNumber;
            int validPageSize = pageSize < 1 ? 10 : pageSize;

            return await Context.Set<T>().AsNoTracking().Skip((validPageNumber - 1) * validPageSize).Take(validPageSize).ToListAsync(cancellationToken);
        }

        public async Task<List<T>> GetEntitiesAsPaginationAsync(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            int validPageNumber = pageNumber < 1 ? 1 : pageNumber;
            int validPageSize = pageSize < 1 ? 10 : pageSize;

            return await query.Skip((validPageNumber - 1) * validPageSize).Take(validPageSize).ToListAsync(cancellationToken);
        }

        public async Task<List<T>> GetEntitiesAsPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await GetEntitiesAsPaginationAsync(Context.Set<T>().AsNoTracking(), pageNumber, pageSize, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public IQueryable<TResult> Join<TJoin, TKey, TResult>(Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TJoin, TKey>> innerKeySelector, Expression<Func<T, TJoin, TResult>> resultSelector) where TJoin : class
        {
            return Context.Set<T>().Join(Context.Set<TJoin>(), outerKeySelector, innerKeySelector, resultSelector);
        }

        public IQueryable<TResult> LeftJoin<TJoin, TKey, TResult>(Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TJoin, TKey>> innerKeySelector, Func<T, TJoin?, TResult> resultSelector) where TJoin : class
        {
            return Context.Set<T>().GroupJoin(Context.Set<TJoin>(), outerKeySelector, innerKeySelector, (outer, innerGroup) => new { outer, innerGroup }).SelectMany(x => x.innerGroup.DefaultIfEmpty(), (x, inner) => resultSelector(x.outer, inner));
        }

        public async Task<int> SoftDeleteAsync(long id, string updatedBy, DateTime updatedAt, CancellationToken cancellationToken = default)
        {
            var entity = await Context.Set<T>().FindAsync([id], cancellationToken);
            if (entity == null)
            {
                return 0;
            }

            var isDeletedProperty = Context.Entry(entity).Property("IsDeleted");
            var updatedByProperty = Context.Entry(entity).Property("UpdatedBy");
            var updatedAtProperty = Context.Entry(entity).Property("UpdatedAt");

            if (isDeletedProperty != null) isDeletedProperty.CurrentValue = true;
            if (updatedByProperty != null) updatedByProperty.CurrentValue = updatedBy;
            if (updatedAtProperty != null) updatedAtProperty.CurrentValue = updatedAt;

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateRangeAsync(IReadOnlyList<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().UpdateRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }
    }
}
