namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeesByDepartmentSpec : Specification<Employee>
{
    public EmployeesByDepartmentSpec(DefaultIdType brandId) =>
        Query.Where(p => p.DepartmentId == brandId);
}
