using HR.Application.Contracts.Repositories.Common;
using HR.Base;
using HR.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.Persistence.Repositories.Common;

public abstract class EfBaseRepository<TEntity>(HrDbContext context) : IRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    private readonly HrDbContext context = context;

    protected DbSet<TEntity> Table => context.Set<TEntity>();

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)

        => await context.Set<TEntity>().AnyAsync(filter, cancellationToken);

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)

        => await context.Set<TEntity>().CountAsync(filter, cancellationToken);

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> filter = null!)
    {
        if (filter == null)
            return await Table.ToListAsync(cancellationToken);
        else
            return await Table.Where(filter).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken)

        => await Table.FindAsync([id], cancellationToken: cancellationToken);

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)

        => await Table.FirstOrDefaultAsync(filter, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)

        => await context.AddRangeAsync(entities, cancellationToken);

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)

        => await Table.AddAsync(entity, cancellationToken);

    public void RemoveRange(IEnumerable<TEntity> entities)

        => Table.RemoveRange(entities);

    public async Task RemoveByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(id, cancellationToken);

        if (entity is not null)
            Table.Remove(entity);
    }

    public void Remove(TEntity id)

        => Table.Remove(id);

    public void Update(TEntity entity)

        => Table.Update(entity);

    public Task SaveChangesAsync(CancellationToken cancellationToken)

        => context.SaveChangesAsync(cancellationToken);

}