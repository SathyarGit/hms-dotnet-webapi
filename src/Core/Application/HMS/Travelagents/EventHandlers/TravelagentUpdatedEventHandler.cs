using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Travelagents.EventHandlers;

public class TravelagentUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Travelagent>>
{
    private readonly ILogger<TravelagentUpdatedEventHandler> _logger;

    public TravelagentUpdatedEventHandler(ILogger<TravelagentUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Travelagent> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}