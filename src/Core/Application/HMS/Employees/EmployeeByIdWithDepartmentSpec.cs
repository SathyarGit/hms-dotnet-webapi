namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeeByIdWithDepartmentSpec : Specification<Employee, EmployeeDetailsDto>, ISingleResultSpecification
{
    public EmployeeByIdWithDepartmentSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Department);
}