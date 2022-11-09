namespace FSH.WebApi.Application.HMS.Departments;

public class DeleteDepartmentRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteDepartmentRequest(Guid id) => Id = id;
}

public class DeleteDepartmentRequestHandler : IRequestHandler<DeleteDepartmentRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Department> _departmentRepo;
    private readonly IReadRepository<Product> _productRepo;
    private readonly IStringLocalizer _t;

    public DeleteDepartmentRequestHandler(IRepositoryWithEvents<Department> departmentRepo, IReadRepository<Product> productRepo, IStringLocalizer<DeleteDepartmentRequestHandler> localizer) =>
        (_departmentRepo, _productRepo, _t) = (departmentRepo, productRepo, localizer);

    public async Task<Guid> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = department ?? throw new NotFoundException(_t["Department {0} Not Found."]);

        await _departmentRepo.DeleteAsync(department, cancellationToken);

        return request.Id;
    }
}