using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Employees.EventHandlers;

public class EmployeeUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Employee>>
{
    private readonly ILogger<EmployeeUpdatedEventHandler> _logger;

    public EmployeeUpdatedEventHandler(ILogger<EmployeeUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Employee> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}