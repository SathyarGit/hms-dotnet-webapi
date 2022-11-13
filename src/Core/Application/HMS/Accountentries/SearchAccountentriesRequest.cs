namespace FSH.WebApi.Application.HMS.Accountentries;

public class SearchAccountentriesRequest : PaginationFilter, IRequest<PaginationResponse<AccountentryDto>>
{
    public DefaultIdType? FolioId { get; set; }
    public DefaultIdType? DepartmentId { get; set; }
    public int? MinimumAmount { get; set; }
    public int? MaximumAmount { get; set; }
}

public class SearchAccountentriesRequestHandler : IRequestHandler<SearchAccountentriesRequest, PaginationResponse<AccountentryDto>>
{
    private readonly IReadRepository<Accountentry> _repository;

    public SearchAccountentriesRequestHandler(IReadRepository<Accountentry> repository) => _repository = repository;

    public async Task<PaginationResponse<AccountentryDto>> Handle(SearchAccountentriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AccountentriesBySearchRequestWithFoliosSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}