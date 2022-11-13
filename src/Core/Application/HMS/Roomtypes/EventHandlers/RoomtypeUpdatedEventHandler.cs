using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomtypes.EventHandlers;

public class RoomtypeUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Roomtype>>
{
    private readonly ILogger<RoomtypeUpdatedEventHandler> _logger;

    public RoomtypeUpdatedEventHandler(ILogger<RoomtypeUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Roomtype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}