namespace FSH.WebApi.Application.HMS.Purchases;

public class SearchPurchasesRequest : PaginationFilter, IRequest<PaginationResponse<PurchaseDto>>
{
    public DefaultIdType? DepartmentId { get; set; }
    public int? MinimumAmount { get; set; }
    public int? MaximumAmount { get; set; }
}

public class SearchPurchasesRequestHandler : IRequestHandler<SearchPurchasesRequest, PaginationResponse<PurchaseDto>>
{
    private readonly IReadRepository<Purchase> _repository;

    public SearchPurchasesRequestHandler(IReadRepository<Purchase> repository) => _repository = repository;

    public async Task<PaginationResponse<PurchaseDto>> Handle(SearchPurchasesRequest request, CancellationToken cancellationToken)
    {
        var spec = new PurchasesBySearchRequestWithDepartmentsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}