namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeeByNameSpec : Specification<Employee>, ISingleResultSpecification
{
    public EmployeeByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}