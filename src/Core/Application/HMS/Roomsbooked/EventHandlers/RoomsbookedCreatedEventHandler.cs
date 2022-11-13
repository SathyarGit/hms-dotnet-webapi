using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomsbookeds.EventHandlers;

public class RoomsbookedCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Roomsbooked>>
{
    private readonly ILogger<RoomsbookedCreatedEventHandler> _logger;

    public RoomsbookedCreatedEventHandler(ILogger<RoomsbookedCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Roomsbooked> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}