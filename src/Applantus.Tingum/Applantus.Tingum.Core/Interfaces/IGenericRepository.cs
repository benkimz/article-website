namespace Applantus.Tingum.Core.Interfaces;

public interface IGenericRepository 
{
    // crud: create, read, update, delete
    Task<T?> SaveAsync<T>(T entity); 

    Task<T?> LoadAsync<T>(Guid id); 

    Task<List<T>?> LoadAllAsync<T>(); 

    Task<T?> AlterAsync<T>(T entity); 

    Task<T?> RemoveAsync<T>(T entity);
}
