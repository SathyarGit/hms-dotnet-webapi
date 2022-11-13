namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class TransactionstatusByIdSpec : Specification<Transactionstatus, TransactionstatusDto>, ISingleResultSpecification
{
    public TransactionstatusByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}