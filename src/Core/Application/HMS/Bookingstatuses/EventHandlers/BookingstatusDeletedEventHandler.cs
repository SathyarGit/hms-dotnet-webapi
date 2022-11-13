using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookingstatuses.EventHandlers;

public class BookingstatusDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Bookingstatus>>
{
    private readonly ILogger<BookingstatusDeletedEventHandler> _logger;

    public BookingstatusDeletedEventHandler(ILogger<BookingstatusDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Bookingstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}