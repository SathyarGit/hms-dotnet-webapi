using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomsbookeds.EventHandlers;

public class RoomsbookedUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Roomsbooked>>
{
    private readonly ILogger<RoomsbookedUpdatedEventHandler> _logger;

    public RoomsbookedUpdatedEventHandler(ILogger<RoomsbookedUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Roomsbooked> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}