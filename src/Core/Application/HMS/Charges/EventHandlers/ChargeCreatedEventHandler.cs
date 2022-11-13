using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Charges.EventHandlers;

public class ChargeCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Charge>>
{
    private readonly ILogger<ChargeCreatedEventHandler> _logger;

    public ChargeCreatedEventHandler(ILogger<ChargeCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Charge> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}