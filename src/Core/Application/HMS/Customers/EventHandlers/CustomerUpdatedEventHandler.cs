using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customers.EventHandlers;

public class CustomerUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Customer>>
{
    private readonly ILogger<CustomerUpdatedEventHandler> _logger;

    public CustomerUpdatedEventHandler(ILogger<CustomerUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Customer> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}