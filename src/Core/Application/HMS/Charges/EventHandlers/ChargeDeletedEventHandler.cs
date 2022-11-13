using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Charges.EventHandlers;

public class ChargeDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Charge>>
{
    private readonly ILogger<ChargeDeletedEventHandler> _logger;

    public ChargeDeletedEventHandler(ILogger<ChargeDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Charge> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}