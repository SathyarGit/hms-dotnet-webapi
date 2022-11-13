namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentriesBySearchRequestWithDepartmentsSpec : EntitiesByPaginationFilterSpec<Accountentry, AccountentryDto>
{
    public AccountentriesBySearchRequestWithDepartmentsSpec(SearchAccountentriesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue)
             .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
             .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}