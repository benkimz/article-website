using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;
using Applantus.Tingum.Core.Interfaces;
using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers;
using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers.IRoles;
using Applantus.Tingum.Infrastruture.Services.Passwords;

namespace Applantus.Tingum.Infrastruture.Data.Repositories.AppUsers;

public class AppUsersRepository : IAppUsersRepository
{
    private readonly IGenericRepository<AppUser> _userRepository; 

    private readonly IUserRolesRepository _userRolesRepository;

    private readonly IPasswordHashing _passwords;

    public AppUsersRepository(IGenericRepository<AppUser> userRepository, IUserRolesRepository userRolesRepository, IPasswordHashing passwords)
    {
        _userRepository = userRepository;
        _userRolesRepository = userRolesRepository; 
        _passwords = passwords;
    }

    public async Task<AppUser?> CreateAsync(string Email, string Password, string? UserName = null, string? Name = null, string? DisplayPhoto = null, string? Biography = null, UserRole? Role = null)
    {
        var roles = await _userRolesRepository.GetAllAsync();
        return await _userRepository.SaveAsync(new AppUser
        {
            Email = Email,
            Password = _passwords.Hash(Password), 
            UserName = UserName ?? Email,
            Name = Name ?? string.Empty,
            DisplayPhoto = DisplayPhoto ?? string.Empty,
            Biography = Biography ?? string.Empty,
            Role = Role ?? roles?.FirstOrDefault(r => r.Name.ToLower() == "standard")
        }); 
    }

    public async Task<List<AppUser>?> GetAllAsync()
    {
        return await _userRepository.LoadAllAsync();
    }

    public async Task<AppUser?> GetAsync(string id)
    {
        return await _userRepository.LoadAsync(id);
    }

    public Task<AppUser?> ModifyAsync(AppUser user)
    {
        return _userRepository.AlterAsync(user);
    }

    public Task<AppUser?> RemoveAsync(AppUser user)
    {
        return _userRepository.RemoveAsync(user);
    }
}
