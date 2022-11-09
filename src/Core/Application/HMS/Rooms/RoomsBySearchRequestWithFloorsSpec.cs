namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomsBySearchRequestWithFloorsSpec : EntitiesByPaginationFilterSpec<Room, RoomDto>
{
    public RoomsBySearchRequestWithFloorsSpec(SearchRoomsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Floor)
            .OrderBy(c => c.RoomNumber, !request.HasOrderBy())
            .Where(p => p.FloorId.Equals(request.FloorId!.Value), request.FloorId.HasValue);
            // .Where(p => p.Rate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            // .Where(p => p.Rate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}