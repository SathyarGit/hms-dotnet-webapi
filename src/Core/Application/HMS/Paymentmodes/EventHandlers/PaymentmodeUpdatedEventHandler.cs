using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Paymentmodes.EventHandlers;

public class PaymentmodeUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Paymentmode>>
{
    private readonly ILogger<PaymentmodeUpdatedEventHandler> _logger;

    public PaymentmodeUpdatedEventHandler(ILogger<PaymentmodeUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Paymentmode> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}