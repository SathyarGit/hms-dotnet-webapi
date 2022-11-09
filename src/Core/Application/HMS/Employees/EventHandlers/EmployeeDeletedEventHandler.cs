using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Employees.EventHandlers;

public class EmployeeDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Employee>>
{
    private readonly ILogger<EmployeeDeletedEventHandler> _logger;

    public EmployeeDeletedEventHandler(ILogger<EmployeeDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Employee> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}