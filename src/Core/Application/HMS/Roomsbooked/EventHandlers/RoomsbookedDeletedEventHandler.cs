using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomsbookeds.EventHandlers;

public class RoomsbookedDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Roomsbooked>>
{
    private readonly ILogger<RoomsbookedDeletedEventHandler> _logger;

    public RoomsbookedDeletedEventHandler(ILogger<RoomsbookedDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Roomsbooked> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}