using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customerclassifications.EventHandlers;

public class CustomerclassificationCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Customerclassification>>
{
    private readonly ILogger<CustomerclassificationCreatedEventHandler> _logger;

    public CustomerclassificationCreatedEventHandler(ILogger<CustomerclassificationCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Customerclassification> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}