namespace FSH.WebApi.Application.HMS.Floors;

public class SearchFloorsRequest : PaginationFilter, IRequest<PaginationResponse<FloorDto>>
{
}

public class FloorsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Floor, FloorDto>
{
    public FloorsBySearchRequestSpec(SearchFloorsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchFloorsRequestHandler : IRequestHandler<SearchFloorsRequest, PaginationResponse<FloorDto>>
{
    private readonly IReadRepository<Floor> _repository;

    public SearchFloorsRequestHandler(IReadRepository<Floor> repository) => _repository = repository;

    public async Task<PaginationResponse<FloorDto>> Handle(SearchFloorsRequest request, CancellationToken cancellationToken)
    {
        var spec = new FloorsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}