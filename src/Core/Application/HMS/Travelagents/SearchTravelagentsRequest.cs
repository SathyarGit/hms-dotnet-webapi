namespace FSH.WebApi.Application.HMS.Travelagents;

public class SearchTravelagentsRequest : PaginationFilter, IRequest<PaginationResponse<TravelagentDto>>
{
}

public class SearchTravelagentsRequestHandler : IRequestHandler<SearchTravelagentsRequest, PaginationResponse<TravelagentDto>>
{
    private readonly IReadRepository<Travelagent> _repository;

    public SearchTravelagentsRequestHandler(IReadRepository<Travelagent> repository) => _repository = repository;

    public async Task<PaginationResponse<TravelagentDto>> Handle(SearchTravelagentsRequest request, CancellationToken cancellationToken)
    {
        var spec = new TravelagentsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}