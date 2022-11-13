using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Travelagents.EventHandlers;

public class TravelagentDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Travelagent>>
{
    private readonly ILogger<TravelagentDeletedEventHandler> _logger;

    public TravelagentDeletedEventHandler(ILogger<TravelagentDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Travelagent> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}