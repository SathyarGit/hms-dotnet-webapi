namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class RoomstatusesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Roomstatus, RoomstatusDto>
{
    public RoomstatusesBySearchRequestSpec(SearchRoomstatusesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}