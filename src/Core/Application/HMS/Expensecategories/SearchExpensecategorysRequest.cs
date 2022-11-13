namespace FSH.WebApi.Application.HMS.Expensecategories;

public class SearchExpensecategoriesRequest : PaginationFilter, IRequest<PaginationResponse<ExpensecategoryDto>>
{
    public DefaultIdType? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchExpensecategoriesRequestHandler : IRequestHandler<SearchExpensecategoriesRequest, PaginationResponse<ExpensecategoryDto>>
{
    private readonly IReadRepository<Expensecategory> _repository;

    public SearchExpensecategoriesRequestHandler(IReadRepository<Expensecategory> repository) => _repository = repository;

    public async Task<PaginationResponse<ExpensecategoryDto>> Handle(SearchExpensecategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExpensecategoriesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}