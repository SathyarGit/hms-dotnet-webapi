using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Folios.EventHandlers;

public class FolioUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Folio>>
{
    private readonly ILogger<FolioUpdatedEventHandler> _logger;

    public FolioUpdatedEventHandler(ILogger<FolioUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Folio> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}