using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomstatuses.EventHandlers;

public class RoomstatusDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Roomstatus>>
{
    private readonly ILogger<RoomstatusDeletedEventHandler> _logger;

    public RoomstatusDeletedEventHandler(ILogger<RoomstatusDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Roomstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}