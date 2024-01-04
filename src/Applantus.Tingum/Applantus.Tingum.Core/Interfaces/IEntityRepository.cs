using Applantus.Tingum.Core.BaseAggregates;

namespace Applantus.Tingum.Core.Interfaces;

public interface IEntityRepository<T> where T : IEntity
{
    Task<T?> GetAsync(string id);

    Task<List<T>?> GetAllAsync();

    IQueryable<T> GetQueryable(); 

    Task<T?> RemoveAsync(T entity); 

    Task<T?> ModifyAsync(T entity); 
}
