using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Accountentries.EventHandlers;

public class AccountentryCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Accountentry>>
{
    private readonly ILogger<AccountentryCreatedEventHandler> _logger;

    public AccountentryCreatedEventHandler(ILogger<AccountentryCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Accountentry> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}