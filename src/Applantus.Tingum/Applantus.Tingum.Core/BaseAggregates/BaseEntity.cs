namespace Applantus.Tingum.Core.BaseAggregates;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; } 

    public DateTime DateCreated { get; set; } 

    public DateTime DateModified { get; set; } 

    public bool IsActive { get; set; } 

    public bool IsDeleted { get; set; } 

    // ~ benkimz: virtual properties that can be overridden 
    public virtual string Name { get; set; } = string.Empty; 

    public virtual string Description { get; set; } = string.Empty; 
}
