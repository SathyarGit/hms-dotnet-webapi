namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class TransactionstatusByNameSpec : Specification<Transactionstatus>, ISingleResultSpecification
{
    public TransactionstatusByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}