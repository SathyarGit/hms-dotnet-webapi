namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeesBySearchRequestWithDepartmentsSpec : EntitiesByPaginationFilterSpec<Employee, EmployeeDto>
{
    public EmployeesBySearchRequestWithDepartmentsSpec(SearchEmployeesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .OrderBy(c => c.Name, !request.HasOrderBy())
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue);
}