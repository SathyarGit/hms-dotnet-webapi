namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class TransactionstatusesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Transactionstatus, TransactionstatusDto>
{
    public TransactionstatusesBySearchRequestSpec(SearchTransactionstatusesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}