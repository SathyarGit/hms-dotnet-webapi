using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookings.EventHandlers;

public class BookingDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Booking>>
{
    private readonly ILogger<BookingDeletedEventHandler> _logger;

    public BookingDeletedEventHandler(ILogger<BookingDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Booking> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}