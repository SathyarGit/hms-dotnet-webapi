using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customerclassifications.EventHandlers;

public class CustomerclassificationDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Customerclassification>>
{
    private readonly ILogger<CustomerclassificationDeletedEventHandler> _logger;

    public CustomerclassificationDeletedEventHandler(ILogger<CustomerclassificationDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Customerclassification> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}