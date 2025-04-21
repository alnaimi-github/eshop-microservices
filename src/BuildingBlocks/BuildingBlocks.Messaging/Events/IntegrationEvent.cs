namespace BuildingBlocks.Messaging.Events;

public record IntegrationEvent
{
    Guid Id => Guid.NewGuid();
    DateTime OccurredOn => DateTime.Now;
    string EventType => GetType().AssemblyQualifiedName!;
}