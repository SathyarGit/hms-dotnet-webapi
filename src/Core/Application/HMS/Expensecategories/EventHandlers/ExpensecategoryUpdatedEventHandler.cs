using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Expensecategories.EventHandlers;

public class ExpensecategoryUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Expensecategory>>
{
    private readonly ILogger<ExpensecategoryUpdatedEventHandler> _logger;

    public ExpensecategoryUpdatedEventHandler(ILogger<ExpensecategoryUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Expensecategory> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}