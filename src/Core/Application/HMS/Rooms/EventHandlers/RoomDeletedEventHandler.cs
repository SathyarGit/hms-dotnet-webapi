using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Rooms.EventHandlers;

public class RoomDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Room>>
{
    private readonly ILogger<RoomDeletedEventHandler> _logger;

    public RoomDeletedEventHandler(ILogger<RoomDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Room> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}