using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Floors.EventHandlers;

public class FloorUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Floor>>
{
    private readonly ILogger<FloorUpdatedEventHandler> _logger;

    public FloorUpdatedEventHandler(ILogger<FloorUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Floor> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}