namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class SearchTransactiontypesRequest : PaginationFilter, IRequest<PaginationResponse<TransactiontypeDto>>
{
}

public class SearchTransactiontypesRequestHandler : IRequestHandler<SearchTransactiontypesRequest, PaginationResponse<TransactiontypeDto>>
{
    private readonly IReadRepository<Transactiontype> _repository;

    public SearchTransactiontypesRequestHandler(IReadRepository<Transactiontype> repository) => _repository = repository;

    public async Task<PaginationResponse<TransactiontypeDto>> Handle(SearchTransactiontypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new TransactiontypesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}