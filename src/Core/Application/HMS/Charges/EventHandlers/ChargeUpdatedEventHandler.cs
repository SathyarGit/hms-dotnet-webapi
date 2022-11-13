using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Charges.EventHandlers;

public class ChargeUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Charge>>
{
    private readonly ILogger<ChargeUpdatedEventHandler> _logger;

    public ChargeUpdatedEventHandler(ILogger<ChargeUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Charge> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}