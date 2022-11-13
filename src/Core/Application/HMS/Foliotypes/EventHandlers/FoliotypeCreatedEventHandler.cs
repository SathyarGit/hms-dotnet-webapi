using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Foliotypes.EventHandlers;

public class FoliotypeCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Foliotype>>
{
    private readonly ILogger<FoliotypeCreatedEventHandler> _logger;

    public FoliotypeCreatedEventHandler(ILogger<FoliotypeCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Foliotype> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}