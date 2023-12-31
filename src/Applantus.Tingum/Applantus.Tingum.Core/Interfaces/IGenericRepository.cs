﻿using Applantus.Tingum.Core.BaseAggregates;

namespace Applantus.Tingum.Core.Interfaces;

public interface IGenericRepository<T> where T : IEntity 
{
    // crud: create, read, update, delete
    Task<T?> SaveAsync(T entity); 

    Task<T?> LoadAsync(string id); 

    Task<List<T>?> LoadAllAsync(); 

    Task<T?> AlterAsync(T entity); 

    Task<T?> RemoveAsync(T entity);

    IQueryable<T> GetQueryable(); 
}
