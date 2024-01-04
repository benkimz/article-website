using System.ComponentModel.DataAnnotations;

namespace Applantus.Tingum.Core.BaseAggregates;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public DateTime DateModified { get; set; } = DateTime.UtcNow; 

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    // ~ benkimz: virtual properties that can be overridden 
    [MaxLength(255)]
    public virtual string Name { get; set; } = string.Empty;

    [MaxLength(512)]
    public virtual string Description { get; set; } = string.Empty; 
}
