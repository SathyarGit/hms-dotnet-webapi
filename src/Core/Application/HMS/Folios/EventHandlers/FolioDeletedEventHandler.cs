using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Folios.EventHandlers;

public class FolioDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Folio>>
{
    private readonly ILogger<FolioDeletedEventHandler> _logger;

    public FolioDeletedEventHandler(ILogger<FolioDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Folio> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}