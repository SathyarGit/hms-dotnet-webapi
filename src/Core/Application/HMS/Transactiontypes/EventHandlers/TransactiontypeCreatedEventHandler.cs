using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Transactiontypes.EventHandlers;

public class TransactiontypeCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Transactiontype>>
{
    private readonly ILogger<TransactiontypeCreatedEventHandler> _logger;

    public TransactiontypeCreatedEventHandler(ILogger<TransactiontypeCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Transactiontype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}