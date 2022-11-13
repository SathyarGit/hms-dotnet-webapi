using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Paymentmodes.EventHandlers;

public class PaymentmodeDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Paymentmode>>
{
    private readonly ILogger<PaymentmodeDeletedEventHandler> _logger;

    public PaymentmodeDeletedEventHandler(ILogger<PaymentmodeDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Paymentmode> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}