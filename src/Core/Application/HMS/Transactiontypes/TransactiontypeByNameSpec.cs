namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class TransactiontypeByNameSpec : Specification<Transactiontype>, ISingleResultSpecification
{
    public TransactiontypeByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}