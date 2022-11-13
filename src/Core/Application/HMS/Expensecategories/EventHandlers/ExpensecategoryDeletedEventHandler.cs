using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Expensecategories.EventHandlers;

public class ExpensecategoryDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Expensecategory>>
{
    private readonly ILogger<ExpensecategoryDeletedEventHandler> _logger;

    public ExpensecategoryDeletedEventHandler(ILogger<ExpensecategoryDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Expensecategory> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}