namespace FSH.WebApi.Application.HMS.Roomtypes;

public class RoomtypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Roomtype, RoomtypeDto>
{
    public RoomtypesBySearchRequestSpec(SearchRoomtypesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}