using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Purchases.EventHandlers;

public class PurchaseUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Purchase>>
{
    private readonly ILogger<PurchaseUpdatedEventHandler> _logger;

    public PurchaseUpdatedEventHandler(ILogger<PurchaseUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Purchase> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}