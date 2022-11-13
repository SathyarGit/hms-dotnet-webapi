namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentriesByPurchaseSpec : Specification<Accountentry>
{
    public AccountentriesByPurchaseSpec(DefaultIdType purchaseId) =>
        Query.Where(p => p.PurchaseId == purchaseId);
}
