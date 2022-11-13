namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchasesBySearchRequestWithDepartmentsSpec : EntitiesByPaginationFilterSpec<Purchase, PurchaseDto>
{
    public PurchasesBySearchRequestWithDepartmentsSpec(SearchPurchasesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}