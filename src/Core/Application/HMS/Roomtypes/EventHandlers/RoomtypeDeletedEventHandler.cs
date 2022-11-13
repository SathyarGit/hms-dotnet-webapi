using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomtypes.EventHandlers;

public class RoomtypeDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Roomtype>>
{
    private readonly ILogger<RoomtypeDeletedEventHandler> _logger;

    public RoomtypeDeletedEventHandler(ILogger<RoomtypeDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Roomtype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}