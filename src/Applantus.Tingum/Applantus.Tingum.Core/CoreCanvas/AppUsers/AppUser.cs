using Applantus.Tingum.Core.BaseAggregates;
using Applantus.Tingum.Core.CoreCanvas.AppUsers.Roles;
using System.ComponentModel.DataAnnotations;

namespace Applantus.Tingum.Core.CoreCanvas.AppUsers;

public class AppUser : BaseEntity
{
    public int AppUserId { get; set; }

    [Required]
    [MaxLength(255)]
    public override string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string UserName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? DisplayPhoto { get; set; } 

    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty; 

    [Required]
    [MaxLength(255)]
    public string Password { get; set; } = string.Empty; 

    [MaxLength(1024)]
    public string? Biography { get; set; } 

    public Role Role { get; set; } 
}
