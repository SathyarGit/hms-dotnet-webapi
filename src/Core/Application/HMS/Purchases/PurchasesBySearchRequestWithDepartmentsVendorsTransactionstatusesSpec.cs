namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchasesBySearchRequestWithDepartmentsVendorsTransactionstatusesSpec : EntitiesByPaginationFilterSpec<Purchase, PurchaseDto>
{
    public PurchasesBySearchRequestWithDepartmentsVendorsTransactionstatusesSpec(SearchPurchasesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .Include(p => p.Vendor)
            .Include(p => p.Transactionstatus)
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue)
            .Where(p => p.VendorId.Equals(request.VendorId!.Value), request.VendorId.HasValue)
            .Where(p => p.TransactionstatusId.Equals(request.TransactionstatusId!.Value), request.TransactionstatusId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}