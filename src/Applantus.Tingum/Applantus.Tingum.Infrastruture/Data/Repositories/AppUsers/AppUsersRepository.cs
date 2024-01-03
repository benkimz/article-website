using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;
using Applantus.Tingum.Core.Interfaces;
using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers;

namespace Applantus.Tingum.Infrastruture.Data.Repositories.AppUsers;

public class AppUsersRepository : IAppUsersRepository
{
    private readonly IGenericRepository<AppUser> _userRepository;

    public AppUsersRepository(IGenericRepository<AppUser> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<AppUser?> CreateAsync(string Email, string Password, string? UserName, string? Name = null, string? DisplayPhoto = null, string? Biography = null, UserRole? Role = null)
    {
        throw new NotImplementedException();
    }

    public Task<List<AppUser>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> ModifyAsync(AppUser user)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> RemoveAsync(AppUser user)
    {
        throw new NotImplementedException();
    }

    /*    public async Task<AppUser?> AddUser()
        {
            var user = new AppUser { 
                Name = "Ben Kim W", 
                UserName = "bkw", 
                Email = "benkim3618@gmail.com", 
            };
            return await _userRepository.SaveAsync(user);
        }*/
}
