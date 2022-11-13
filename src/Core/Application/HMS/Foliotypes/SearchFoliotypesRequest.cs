namespace FSH.WebApi.Application.HMS.Foliotypes;

public class SearchFoliotypesRequest : PaginationFilter, IRequest<PaginationResponse<FoliotypeDto>>
{
    public DefaultIdType? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchFoliotypesRequestHandler : IRequestHandler<SearchFoliotypesRequest, PaginationResponse<FoliotypeDto>>
{
    private readonly IReadRepository<Foliotype> _repository;

    public SearchFoliotypesRequestHandler(IReadRepository<Foliotype> repository) => _repository = repository;

    public async Task<PaginationResponse<FoliotypeDto>> Handle(SearchFoliotypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new FoliotypesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}