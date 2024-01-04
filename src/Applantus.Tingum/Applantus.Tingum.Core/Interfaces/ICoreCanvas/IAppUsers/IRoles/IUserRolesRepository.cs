using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;

namespace Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers.IRoles;

public interface IUserRolesRepository : IEntityRepository<UserRole>
{
    Task<UserRole?> CreateAsync(string name, string? description = null); 
}
