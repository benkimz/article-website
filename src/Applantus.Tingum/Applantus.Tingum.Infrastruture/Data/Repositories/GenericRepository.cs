using Applantus.Tingum.Core.BaseAggregates;
using Applantus.Tingum.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Applantus.Tingum.Infrastruture.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly SystemDbContext _context;

    private readonly DbSet<T> _dbSet;

    public GenericRepository(SystemDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public Task<T?> AlterAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>?> LoadAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> LoadAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> RemoveAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> SaveAsync(T entity)
    {
        entity.DateCreated = DateTime.UtcNow;
        entity.DateModified = DateTime.UtcNow;
        entity.IsActive = true; entity.IsDeleted = false;
        var results = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return results.Entity;
    }
}
