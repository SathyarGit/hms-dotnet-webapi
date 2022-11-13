using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Vendors.EventHandlers;

public class VendorUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Vendor>>
{
    private readonly ILogger<VendorUpdatedEventHandler> _logger;

    public VendorUpdatedEventHandler(ILogger<VendorUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Vendor> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}