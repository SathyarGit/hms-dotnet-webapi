using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Accountentries.EventHandlers;

public class AccountentryDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Accountentry>>
{
    private readonly ILogger<AccountentryDeletedEventHandler> _logger;

    public AccountentryDeletedEventHandler(ILogger<AccountentryDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Accountentry> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}