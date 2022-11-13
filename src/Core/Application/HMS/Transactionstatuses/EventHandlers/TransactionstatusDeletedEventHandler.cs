using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactionstatuses.EventHandlers;

public class TransactionstatusDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Transactionstatus>>
{
    private readonly ILogger<TransactionstatusDeletedEventHandler> _logger;

    public TransactionstatusDeletedEventHandler(ILogger<TransactionstatusDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Transactionstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}