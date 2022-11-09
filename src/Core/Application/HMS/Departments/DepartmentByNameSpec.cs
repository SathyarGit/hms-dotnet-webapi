namespace FSH.WebApi.Application.HMS.Departments;

public class DepartmentByNameSpec : Specification<Department>, ISingleResultSpecification
{
    public DepartmentByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}