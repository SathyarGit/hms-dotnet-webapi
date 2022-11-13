using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Expensecategories.EventHandlers;

public class ExpensecategoryCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Expensecategory>>
{
    private readonly ILogger<ExpensecategoryCreatedEventHandler> _logger;

    public ExpensecategoryCreatedEventHandler(ILogger<ExpensecategoryCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Expensecategory> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}