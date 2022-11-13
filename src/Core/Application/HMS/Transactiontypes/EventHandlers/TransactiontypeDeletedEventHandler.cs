using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Transactiontypes.EventHandlers;

public class TransactiontypeDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Transactiontype>>
{
    private readonly ILogger<TransactiontypeDeletedEventHandler> _logger;

    public TransactiontypeDeletedEventHandler(ILogger<TransactiontypeDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Transactiontype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}