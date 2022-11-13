using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Vendors.EventHandlers;

public class VendorDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Vendor>>
{
    private readonly ILogger<VendorDeletedEventHandler> _logger;

    public VendorDeletedEventHandler(ILogger<VendorDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Vendor> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}