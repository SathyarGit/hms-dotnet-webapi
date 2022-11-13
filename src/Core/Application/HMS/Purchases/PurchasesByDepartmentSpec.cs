namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchasesByDepartmentSpec : Specification<Purchase>
{
    public PurchasesByDepartmentSpec(DefaultIdType departmentId) =>
        Query.Where(p => p.DepartmentId == departmentId);
}
