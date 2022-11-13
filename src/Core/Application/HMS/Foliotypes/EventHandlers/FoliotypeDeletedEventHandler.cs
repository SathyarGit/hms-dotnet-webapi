using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Foliotypes.EventHandlers;

public class FoliotypeDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Foliotype>>
{
    private readonly ILogger<FoliotypeDeletedEventHandler> _logger;

    public FoliotypeDeletedEventHandler(ILogger<FoliotypeDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Foliotype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}