namespace Ordering.Application.Orders.EventHandlers;

internal sealed class OrderCreatedEventHandler (ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}