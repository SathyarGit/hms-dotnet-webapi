using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomstatuses.EventHandlers;

public class RoomstatusCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Roomstatus>>
{
    private readonly ILogger<RoomstatusCreatedEventHandler> _logger;

    public RoomstatusCreatedEventHandler(ILogger<RoomstatusCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Roomstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}