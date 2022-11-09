namespace FSH.WebApi.Application.HMS.Employees;

public class SearchEmployeesRequest : PaginationFilter, IRequest<PaginationResponse<EmployeeDto>>
{
    public DefaultIdType? DepartmentId { get; set; }
    // public decimal? MinimumRate { get; set; }
    // public decimal? MaximumRate { get; set; }
}

public class SearchEmployeesRequestHandler : IRequestHandler<SearchEmployeesRequest, PaginationResponse<EmployeeDto>>
{
    private readonly IReadRepository<Employee> _repository;

    public SearchEmployeesRequestHandler(IReadRepository<Employee> repository) => _repository = repository;

    public async Task<PaginationResponse<EmployeeDto>> Handle(SearchEmployeesRequest request, CancellationToken cancellationToken)
    {
        var spec = new EmployeesBySearchRequestWithDepartmentsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}