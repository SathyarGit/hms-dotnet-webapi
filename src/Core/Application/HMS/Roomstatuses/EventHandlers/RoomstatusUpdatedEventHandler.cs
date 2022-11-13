using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomstatuses.EventHandlers;

public class RoomstatusUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Roomstatus>>
{
    private readonly ILogger<RoomstatusUpdatedEventHandler> _logger;

    public RoomstatusUpdatedEventHandler(ILogger<RoomstatusUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Roomstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}