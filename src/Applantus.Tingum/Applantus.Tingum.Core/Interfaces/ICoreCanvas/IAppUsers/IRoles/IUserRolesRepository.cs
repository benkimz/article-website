using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;

namespace Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers.IRoles;

public interface IUserRolesRepository
{
    Task<UserRole?> CreateAsync(string name, string? description = null);

    Task<UserRole?> GetAsync(string id); 

    Task<List<UserRole>?> GetAllAsync(); 
}
