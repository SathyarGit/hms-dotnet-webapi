using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Employees;

public class DeleteEmployeeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteEmployeeRequest(DefaultIdType id) => Id = id;
}

public class DeleteEmployeeRequestHandler : IRequestHandler<DeleteEmployeeRequest, DefaultIdType>
{
    private readonly IRepository<Employee> _repository;
    private readonly IStringLocalizer _t;

    public DeleteEmployeeRequestHandler(IRepository<Employee> repository, IStringLocalizer<DeleteEmployeeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = employee ?? throw new NotFoundException(_t["Employee {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        employee.DomainEvents.Add(EntityDeletedEvent.WithEntity(employee));

        await _repository.DeleteAsync(employee, cancellationToken);

        return request.Id;
    }
}