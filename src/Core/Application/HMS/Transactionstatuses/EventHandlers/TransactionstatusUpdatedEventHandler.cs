using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactionstatuses.EventHandlers;

public class TransactionstatusUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Transactionstatus>>
{
    private readonly ILogger<TransactionstatusUpdatedEventHandler> _logger;

    public TransactionstatusUpdatedEventHandler(ILogger<TransactionstatusUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Transactionstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}