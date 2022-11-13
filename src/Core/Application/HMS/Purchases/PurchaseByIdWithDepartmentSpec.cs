namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchaseByIdWithDepartmentSpec : Specification<Purchase, PurchaseDetailsDto>, ISingleResultSpecification
{
    public PurchaseByIdWithDepartmentSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Department);
}