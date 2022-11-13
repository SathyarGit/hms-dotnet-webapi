using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Floors.EventHandlers;

public class FloorCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Floor>>
{
    private readonly ILogger<FloorCreatedEventHandler> _logger;

    public FloorCreatedEventHandler(ILogger<FloorCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Floor> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}