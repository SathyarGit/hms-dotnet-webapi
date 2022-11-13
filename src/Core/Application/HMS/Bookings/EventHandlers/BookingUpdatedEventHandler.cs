using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookings.EventHandlers;

public class BookingUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Booking>>
{
    private readonly ILogger<BookingUpdatedEventHandler> _logger;

    public BookingUpdatedEventHandler(ILogger<BookingUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Booking> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}