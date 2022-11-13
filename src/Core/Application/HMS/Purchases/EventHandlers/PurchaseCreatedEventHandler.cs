using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Purchases.EventHandlers;

public class PurchaseCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Purchase>>
{
    private readonly ILogger<PurchaseCreatedEventHandler> _logger;

    public PurchaseCreatedEventHandler(ILogger<PurchaseCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Purchase> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}