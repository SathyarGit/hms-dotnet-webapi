namespace FSH.WebApi.Application.HMS.Foliotypes;

public class SearchFoliotypesRequest : PaginationFilter, IRequest<PaginationResponse<FoliotypeDto>>
{
}

public class FoliotypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Foliotype, FoliotypeDto>
{
    public FoliotypesBySearchRequestSpec(SearchFoliotypesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchFoliotypesRequestHandler : IRequestHandler<SearchFoliotypesRequest, PaginationResponse<FoliotypeDto>>
{
    private readonly IReadRepository<Foliotype> _repository;

    public SearchFoliotypesRequestHandler(IReadRepository<Foliotype> repository) => _repository = repository;

    public async Task<PaginationResponse<FoliotypeDto>> Handle(SearchFoliotypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new FoliotypesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}