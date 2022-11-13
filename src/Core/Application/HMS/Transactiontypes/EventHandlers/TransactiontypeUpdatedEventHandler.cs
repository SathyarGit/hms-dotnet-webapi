using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Transactiontypes.EventHandlers;

public class TransactiontypeUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Transactiontype>>
{
    private readonly ILogger<TransactiontypeUpdatedEventHandler> _logger;

    public TransactiontypeUpdatedEventHandler(ILogger<TransactiontypeUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Transactiontype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}