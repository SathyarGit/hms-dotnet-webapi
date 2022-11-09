using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Floors.EventHandlers;

public class FloorDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Floor>>
{
    private readonly ILogger<FloorDeletedEventHandler> _logger;

    public FloorDeletedEventHandler(ILogger<FloorDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Floor> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}