namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentryByIdWithDepartmentSpec : Specification<Accountentry, AccountentryDetailsDto>, ISingleResultSpecification
{
    public AccountentryByIdWithDepartmentSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Department);
}