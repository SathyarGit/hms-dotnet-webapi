namespace FSH.WebApi.Application.HMS.Employees;

public class GetEmployeeRequest : IRequest<EmployeeDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetEmployeeRequest(DefaultIdType id) => Id = id;
}

public class GetEmployeeRequestHandler : IRequestHandler<GetEmployeeRequest, EmployeeDetailsDto>
{
    private readonly IRepository<Employee> _repository;
    private readonly IStringLocalizer _t;

    public GetEmployeeRequestHandler(IRepository<Employee> repository, IStringLocalizer<GetEmployeeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<EmployeeDetailsDto> Handle(GetEmployeeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Employee, EmployeeDetailsDto>)new EmployeeByIdWithDepartmentSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Employee {0} Not Found.", request.Id]);
}