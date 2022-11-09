namespace FSH.WebApi.Application.HMS.Departments;

public class CreateDepartmentRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateDepartmentRequestValidator : CustomValidator<CreateDepartmentRequest>
{
    public CreateDepartmentRequestValidator(IReadRepository<Department> repository, IStringLocalizer<CreateDepartmentRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new DepartmentByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Department {0} already Exists.", name]);
}

public class CreateDepartmentRequestHandler : IRequestHandler<CreateDepartmentRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Department> _repository;

    public CreateDepartmentRequestHandler(IRepositoryWithEvents<Department> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = new Department(request.Name, request.Description);

        await _repository.AddAsync(department, cancellationToken);

        return department.Id;
    }
}

