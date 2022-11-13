namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class SearchRoomsbookedsRequest : PaginationFilter, IRequest<PaginationResponse<RoomsbookedDto>>
{
    public DefaultIdType? RoomId { get; set; }
    public DefaultIdType? BookingId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchRoomsbookedsRequestHandler : IRequestHandler<SearchRoomsbookedsRequest, PaginationResponse<RoomsbookedDto>>
{
    private readonly IReadRepository<Roomsbooked> _repository;

    public SearchRoomsbookedsRequestHandler(IReadRepository<Roomsbooked> repository) => _repository = repository;

    public async Task<PaginationResponse<RoomsbookedDto>> Handle(SearchRoomsbookedsRequest request, CancellationToken cancellationToken)
    {
        var spec = new RoomsbookedsBySearchRequestWithRoomsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}