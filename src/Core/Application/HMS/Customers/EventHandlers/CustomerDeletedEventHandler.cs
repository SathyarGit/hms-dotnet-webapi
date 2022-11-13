using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customers.EventHandlers;

public class CustomerDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Customer>>
{
    private readonly ILogger<CustomerDeletedEventHandler> _logger;

    public CustomerDeletedEventHandler(ILogger<CustomerDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Customer> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}