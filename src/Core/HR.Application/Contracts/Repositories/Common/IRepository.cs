using HR.Base;
using System.Linq.Expressions;

namespace HR.Application.Contracts.Repositories.Common;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> filter = null!);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
    Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    public void RemoveRange(IEnumerable<TEntity> entities);
    public Task RemoveByIdAsync(int id, CancellationToken cancellationToken);
    public void Remove(TEntity entity);
    public void Update(TEntity entity);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
