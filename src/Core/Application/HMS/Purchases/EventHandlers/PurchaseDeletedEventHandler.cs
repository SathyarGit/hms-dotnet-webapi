using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Purchases.EventHandlers;

public class PurchaseDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Purchase>>
{
    private readonly ILogger<PurchaseDeletedEventHandler> _logger;

    public PurchaseDeletedEventHandler(ILogger<PurchaseDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Purchase> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}