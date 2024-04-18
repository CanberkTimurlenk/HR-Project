﻿using HR.Base;
using System.Linq.Expressions;

namespace HR.Application.Contracts.Repositories.Common;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null!);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> FindAsync(Guid id);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

    public Task AddRangeAsync(IEnumerable<TEntity> entities);
    public Task AddAsync(TEntity entity);
    public void RemoveRange(IEnumerable<TEntity> entities);
    public Task RemoveByIdAsync(Guid id);
    public void Remove(TEntity entity);
    public void Update(TEntity entity);
}
