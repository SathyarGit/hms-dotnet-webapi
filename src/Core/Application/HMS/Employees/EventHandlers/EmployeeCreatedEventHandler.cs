using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Employees.EventHandlers;

public class EmployeeCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Employee>>
{
    private readonly ILogger<EmployeeCreatedEventHandler> _logger;

    public EmployeeCreatedEventHandler(ILogger<EmployeeCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Employee> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}