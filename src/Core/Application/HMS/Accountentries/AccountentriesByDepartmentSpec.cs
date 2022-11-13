namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentriesByDepartmentSpec : Specification<Accountentry>
{
    public AccountentriesByDepartmentSpec(DefaultIdType departmentId) =>
        Query.Where(p => p.DepartmentId == departmentId);
}
