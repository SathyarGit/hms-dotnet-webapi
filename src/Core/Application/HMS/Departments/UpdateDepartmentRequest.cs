namespace FSH.WebApi.Application.HMS.Departments;

public class UpdateDepartmentRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateDepartmentRequestValidator : CustomValidator<UpdateDepartmentRequest>
{
    public UpdateDepartmentRequestValidator(IRepository<Department> repository, IStringLocalizer<UpdateDepartmentRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (department, name, ct) =>
                    await repository.GetBySpecAsync(new DepartmentByNameSpec(name), ct)
                        is not Department existingDepartment || existingDepartment.Id == department.Id)
                .WithMessage((_, name) => T["Department {0} already Exists.", name]);
}

public class UpdateDepartmentRequestHandler : IRequestHandler<UpdateDepartmentRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Department> _repository;
    private readonly IStringLocalizer _t;

    public UpdateDepartmentRequestHandler(IRepositoryWithEvents<Department> repository, IStringLocalizer<UpdateDepartmentRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = department
        ?? throw new NotFoundException(_t["Department {0} Not Found.", request.Id]);

        department.Update(request.Name, request.Description);

        await _repository.UpdateAsync(department, cancellationToken);

        return request.Id;
    }
}