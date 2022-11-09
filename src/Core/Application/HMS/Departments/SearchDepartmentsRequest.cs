namespace FSH.WebApi.Application.HMS.Departments;

public class SearchDepartmentsRequest : PaginationFilter, IRequest<PaginationResponse<DepartmentDto>>
{
}

public class DepartmentsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Department, DepartmentDto>
{
    public DepartmentsBySearchRequestSpec(SearchDepartmentsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchDepartmentsRequestHandler : IRequestHandler<SearchDepartmentsRequest, PaginationResponse<DepartmentDto>>
{
    private readonly IReadRepository<Department> _repository;

    public SearchDepartmentsRequestHandler(IReadRepository<Department> repository) => _repository = repository;

    public async Task<PaginationResponse<DepartmentDto>> Handle(SearchDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var spec = new DepartmentsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}