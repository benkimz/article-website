using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.Interfaces;

namespace Applantus.Tingum.Infrastruture.Data.Repositories.AppUsers;

public class AppUsersRepository : IAppUsersRepository
{
    private readonly IGenericRepository<AppUser> _userRepository;

    public AppUsersRepository(IGenericRepository<AppUser> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AppUser?> AddUser()
    {
        var user = new AppUser { 
            Name = "Ben Kim W", 
            UserName = "bkw", 
            Email = "benkim3618@gmail.com", 
        };
        return await _userRepository.SaveAsync(user);
    }
}
