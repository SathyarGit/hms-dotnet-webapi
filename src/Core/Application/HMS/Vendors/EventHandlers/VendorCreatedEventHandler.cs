using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Vendors.EventHandlers;

public class VendorCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Vendor>>
{
    private readonly ILogger<VendorCreatedEventHandler> _logger;

    public VendorCreatedEventHandler(ILogger<VendorCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Vendor> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}