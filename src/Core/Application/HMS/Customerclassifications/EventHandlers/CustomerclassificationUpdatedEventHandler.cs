using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customerclassifications.EventHandlers;

public class CustomerclassificationUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Customerclassification>>
{
    private readonly ILogger<CustomerclassificationUpdatedEventHandler> _logger;

    public CustomerclassificationUpdatedEventHandler(ILogger<CustomerclassificationUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Customerclassification> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}