namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class SearchTransactionstatusesRequest : PaginationFilter, IRequest<PaginationResponse<TransactionstatusDto>>
{
}

public class SearchTransactionstatusesRequestHandler : IRequestHandler<SearchTransactionstatusesRequest, PaginationResponse<TransactionstatusDto>>
{
    private readonly IReadRepository<Transactionstatus> _repository;

    public SearchTransactionstatusesRequestHandler(IReadRepository<Transactionstatus> repository) => _repository = repository;

    public async Task<PaginationResponse<TransactionstatusDto>> Handle(SearchTransactionstatusesRequest request, CancellationToken cancellationToken)
    {
        var spec = new TransactionstatusesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}