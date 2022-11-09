using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Rooms.EventHandlers;

public class RoomUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Room>>
{
    private readonly ILogger<RoomUpdatedEventHandler> _logger;

    public RoomUpdatedEventHandler(ILogger<RoomUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Room> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}