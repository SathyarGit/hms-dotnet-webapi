using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomtypes.EventHandlers;

public class RoomtypeCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Roomtype>>
{
    private readonly ILogger<RoomtypeCreatedEventHandler> _logger;

    public RoomtypeCreatedEventHandler(ILogger<RoomtypeCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Roomtype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}