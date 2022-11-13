using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactionstatuses.EventHandlers;

public class TransactionstatusCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Transactionstatus>>
{
    private readonly ILogger<TransactionstatusCreatedEventHandler> _logger;

    public TransactionstatusCreatedEventHandler(ILogger<TransactionstatusCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Transactionstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}