﻿using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;

namespace Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers;

public interface IAppUsersRepository  
{
    Task<AppUser?> CreateAsync(string Email, string Password, string? UserName, string? Name = null, string? DisplayPhoto = null, string? Biography = null, UserRole? Role = null);
}
