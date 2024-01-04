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

    public async Task<T?> AlterAsync(T entity)
    {
        entity.DateModified = DateTime.UtcNow;
        var results = _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return results.Entity; 
    }

    public async Task<List<T>?> LoadAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> LoadAsync(string id)
    {
        return await _dbSet.FindAsync(id); 
    }

    public async Task<T?> RemoveAsync(T entity)
    {
        var results = _dbSet.Remove(entity); 
        await _context.SaveChangesAsync(); 
        return results.Entity; 
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

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }
}
