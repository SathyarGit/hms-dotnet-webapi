namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeesByDepartmentSpec : Specification<Employee>
{
    public EmployeesByDepartmentSpec(DefaultIdType departmentId) =>
        Query.Where(p => p.DepartmentId == departmentId);
}
