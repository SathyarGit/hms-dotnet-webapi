using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Accountentries.EventHandlers;

public class AccountentryUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Accountentry>>
{
    private readonly ILogger<AccountentryUpdatedEventHandler> _logger;

    public AccountentryUpdatedEventHandler(ILogger<AccountentryUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Accountentry> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}