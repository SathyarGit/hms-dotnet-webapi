using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Paymentmodes.EventHandlers;

public class PaymentmodeCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Paymentmode>>
{
    private readonly ILogger<PaymentmodeCreatedEventHandler> _logger;

    public PaymentmodeCreatedEventHandler(ILogger<PaymentmodeCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Paymentmode> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}