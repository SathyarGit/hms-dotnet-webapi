using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customers.EventHandlers;

public class CustomerCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Customer>>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger;

    public CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Customer> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}