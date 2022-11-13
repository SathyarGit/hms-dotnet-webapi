namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class TransactiontypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Transactiontype, TransactiontypeDto>
{
    public TransactiontypesBySearchRequestSpec(SearchTransactiontypesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}