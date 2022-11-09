using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Employees;

public class CreateEmployeeRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Notes { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public FileUploadRequest? Image { get; set; }

}

public class CreateEmployeeRequestHandler : IRequestHandler<CreateEmployeeRequest, DefaultIdType>
{
    private readonly IRepository<Employee> _repository;
    private readonly IFileStorageService _file;

    public CreateEmployeeRequestHandler(IRepository<Employee> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        string employeeImagePath = await _file.UploadAsync<Employee>(request.Image, FileType.Image, cancellationToken);

        var employee = new Employee(request.Name, request.Notes, request.DepartmentId, employeeImagePath);

        // Add Domain Events to be raised after the commit
        employee.DomainEvents.Add(EntityCreatedEvent.WithEntity(employee));

        await _repository.AddAsync(employee, cancellationToken);

        return employee.Id;
    }
}