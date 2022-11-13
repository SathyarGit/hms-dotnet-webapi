using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookingstatuses.EventHandlers;

public class BookingstatusCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Bookingstatus>>
{
    private readonly ILogger<BookingstatusCreatedEventHandler> _logger;

    public BookingstatusCreatedEventHandler(ILogger<BookingstatusCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Bookingstatus> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}