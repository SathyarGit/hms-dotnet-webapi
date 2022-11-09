using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Employees;

public class UpdateEmployeeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Notes { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public bool DeleteCurrentImage { get; set; } = false;
    public FileUploadRequest? Image { get; set; }
}

public class UpdateEmployeeRequestHandler : IRequestHandler<UpdateEmployeeRequest, DefaultIdType>
{
    readonly IRepository<Employee> _repository;
    readonly IStringLocalizer _t;
    readonly IFileStorageService _file;

    public UpdateEmployeeRequestHandler(IRepository<Employee> repository, IStringLocalizer<UpdateEmployeeRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = employee ?? throw new NotFoundException(_t["Employee {0} Not Found.", request.Id]);

        // Remove old image if flag is set
        if (request.DeleteCurrentImage)
        {
            string? currentEmployeeImagePath = employee.ImagePath;
            if (!string.IsNullOrEmpty(currentEmployeeImagePath))
            {
                string root = Directory.GetCurrentDirectory();
                _file.Remove(Path.Combine(root, currentEmployeeImagePath));
            }

            employee = employee.ClearImagePath();
        }

        string? employeeImagePath = request.Image is not null
            ? await _file.UploadAsync<Employee>(request.Image, FileType.Image, cancellationToken)
            : null;

        var updatedEmployee = employee.Update(request.Name, request.Notes, request.DepartmentId, employeeImagePath);

        // Add Domain Events to be raised after the commit
        employee.DomainEvents.Add(EntityUpdatedEvent.WithEntity(employee));

        await _repository.UpdateAsync(updatedEmployee, cancellationToken);

        return request.Id;
    }
}