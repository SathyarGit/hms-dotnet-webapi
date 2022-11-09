using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Rooms.EventHandlers;

public class RoomCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Room>>
{
    private readonly ILogger<RoomCreatedEventHandler> _logger;

    public RoomCreatedEventHandler(ILogger<RoomCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Room> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}