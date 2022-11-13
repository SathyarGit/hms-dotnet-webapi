using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Travelagents.EventHandlers;

public class TravelagentCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Travelagent>>
{
    private readonly ILogger<TravelagentCreatedEventHandler> _logger;

    public TravelagentCreatedEventHandler(ILogger<TravelagentCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Travelagent> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}