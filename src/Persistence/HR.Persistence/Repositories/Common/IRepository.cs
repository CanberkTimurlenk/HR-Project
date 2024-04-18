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

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)

        => await context.Set<TEntity>().AnyAsync(filter);

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)

        => await context.Set<TEntity>().CountAsync(filter);

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null!)
    {
        if (filter == null)
            return await Table.ToListAsync();
        else
            return await Table.Where(filter).ToListAsync();
    }

    public async Task<TEntity?> FindAsync(Guid id)

        => await Table.FindAsync(id);

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)

        => await Table.FirstOrDefaultAsync(filter);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await context.AddRangeAsync(entities);
    }

    public async Task AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)

        => Table.RemoveRange(entities);

    public async Task RemoveByIdAsync(Guid id)
    {
        var entity = await FindAsync(id);

        if (entity is not null)
            Table.Remove(entity);
    }

    public void Remove(TEntity id)

        => Table.Remove(id);

    public void Update(TEntity entity)

        => Table.Update(entity);

}