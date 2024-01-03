namespace Applantus.Tingum.Core.BaseAggregates;

public interface IEntity
{
    Guid Id { get; set; } 

    DateTime DateCreated { get; set; } 

    DateTime DateModified { get; set; } 
}
