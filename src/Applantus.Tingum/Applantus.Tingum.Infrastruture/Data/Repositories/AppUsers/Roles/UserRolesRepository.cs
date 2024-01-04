using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;
using Applantus.Tingum.Core.Interfaces;
using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers.IRoles;

namespace Applantus.Tingum.Infrastruture.Data.Repositories.AppUsers.Roles;

public class UserRolesRepository : IUserRolesRepository
{
    private readonly IGenericRepository<UserRole> _rolesRepository;

    public UserRolesRepository(IGenericRepository<UserRole> rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }

    public Task<UserRole?> CreateAsync(string name, string? description = null)
    {
        return _rolesRepository.SaveAsync(new UserRole
        {
            Name = name,
            Description = description ?? string.Empty 
        }); 
    }

    public Task<List<UserRole>?> GetAllAsync()
    {
        return _rolesRepository.LoadAllAsync();
    }

    public Task<UserRole?> GetAsync(string id)
    {
        return _rolesRepository.LoadAsync(id);
    }

    public IQueryable<UserRole> GetQueryable()
    {
        return _rolesRepository.GetQueryable();
    }

    public Task<UserRole?> ModifyAsync(UserRole entity)
    {
        return _rolesRepository.AlterAsync(entity);
    }

    public Task<UserRole?> RemoveAsync(UserRole entity)
    {
        return _rolesRepository.RemoveAsync(entity);
    }
}
