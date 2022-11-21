namespace FSH.WebApi.Application.HMS.Roomtypes;

public class SearchRoomtypesRequest : PaginationFilter, IRequest<PaginationResponse<RoomtypeDto>>
{
}

public class RoomtypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Roomtype, RoomtypeDto>
{
    public RoomtypesBySearchRequestSpec(SearchRoomtypesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchRoomtypesRequestHandler : IRequestHandler<SearchRoomtypesRequest, PaginationResponse<RoomtypeDto>>
{
    private readonly IReadRepository<Roomtype> _repository;

    public SearchRoomtypesRequestHandler(IReadRepository<Roomtype> repository) => _repository = repository;

    public async Task<PaginationResponse<RoomtypeDto>> Handle(SearchRoomtypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new RoomtypesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}