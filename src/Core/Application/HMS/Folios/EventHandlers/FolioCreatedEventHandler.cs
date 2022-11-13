using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Folios.EventHandlers;

public class FolioCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Folio>>
{
    private readonly ILogger<FolioCreatedEventHandler> _logger;

    public FolioCreatedEventHandler(ILogger<FolioCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Folio> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}