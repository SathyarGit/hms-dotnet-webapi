namespace FSH.WebApi.Application.HMS.Rooms;

public class SearchRoomsRequest : PaginationFilter, IRequest<PaginationResponse<RoomDto>>
{
    public DefaultIdType? FloorId { get; set; }
    public DefaultIdType? RoomtypeId { get; set; }
}

public class SearchRoomsRequestHandler : IRequestHandler<SearchRoomsRequest, PaginationResponse<RoomDto>>
{
    private readonly IReadRepository<Room> _repository;

    public SearchRoomsRequestHandler(IReadRepository<Room> repository) => _repository = repository;

    public async Task<PaginationResponse<RoomDto>> Handle(SearchRoomsRequest request, CancellationToken cancellationToken)
    {
        var spec = new RoomsBySearchRequestWithFloorsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}