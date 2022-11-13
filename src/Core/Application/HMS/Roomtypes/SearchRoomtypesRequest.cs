namespace FSH.WebApi.Application.HMS.Roomtypes;

public class SearchRoomtypesRequest : PaginationFilter, IRequest<PaginationResponse<RoomtypeDto>>
{
    public DefaultIdType? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchRoomtypesRequestHandler : IRequestHandler<SearchRoomtypesRequest, PaginationResponse<RoomtypeDto>>
{
    private readonly IReadRepository<Roomtype> _repository;

    public SearchRoomtypesRequestHandler(IReadRepository<Roomtype> repository) => _repository = repository;

    public async Task<PaginationResponse<RoomtypeDto>> Handle(SearchRoomtypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new RoomtypesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}