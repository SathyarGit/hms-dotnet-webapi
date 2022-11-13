namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentriesByExpensecategorySpec : Specification<Accountentry>
{
    public AccountentriesByExpensecategorySpec(DefaultIdType expensecategoryId) =>
        Query.Where(p => p.ExpensecategoryId == expensecategoryId);
}
