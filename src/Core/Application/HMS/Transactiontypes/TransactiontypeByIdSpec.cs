namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class TransactiontypeByIdSpec : Specification<Transactiontype, TransactiontypeDto>, ISingleResultSpecification
{
    public TransactiontypeByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}