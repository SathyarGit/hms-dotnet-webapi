using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Foliotypes.EventHandlers;

public class FoliotypeUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Foliotype>>
{
    private readonly ILogger<FoliotypeUpdatedEventHandler> _logger;

    public FoliotypeUpdatedEventHandler(ILogger<FoliotypeUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Foliotype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}