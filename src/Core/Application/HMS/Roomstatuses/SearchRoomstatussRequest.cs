namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class SearchRoomstatusesRequest : PaginationFilter, IRequest<PaginationResponse<RoomstatusDto>>
{
    public DefaultIdType? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchRoomstatusesRequestHandler : IRequestHandler<SearchRoomstatusesRequest, PaginationResponse<RoomstatusDto>>
{
    private readonly IReadRepository<Roomstatus> _repository;

    public SearchRoomstatusesRequestHandler(IReadRepository<Roomstatus> repository) => _repository = repository;

    public async Task<PaginationResponse<RoomstatusDto>> Handle(SearchRoomstatusesRequest request, CancellationToken cancellationToken)
    {
        var spec = new RoomstatusesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}