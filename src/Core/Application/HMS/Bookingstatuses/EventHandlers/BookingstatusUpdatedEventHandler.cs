using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookingstatuses.EventHandlers;

public class BookingstatusUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Bookingstatus>>
{
    private readonly ILogger<BookingstatusUpdatedEventHandler> _logger;

    public BookingstatusUpdatedEventHandler(ILogger<BookingstatusUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Bookingstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}