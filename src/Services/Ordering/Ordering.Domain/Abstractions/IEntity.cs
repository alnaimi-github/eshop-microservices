namespace Ordering.Domain.Abstractions;

public interface IEntity<out T> : IEntity
{ 
    T Id { get; }
}
public interface IEntity
{
    DateTime? CreatedAt { get; }
    string? CreatedBy { get; }
    DateTime? LastModified { get; } 
    string? LastModifiedBy { get; }
}