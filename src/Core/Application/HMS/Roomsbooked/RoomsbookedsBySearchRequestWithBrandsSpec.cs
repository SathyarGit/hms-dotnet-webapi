namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class RoomsbookedsBySearchRequestWithRoomsSpec : EntitiesByPaginationFilterSpec<Roomsbooked, RoomsbookedDto>
{
    public RoomsbookedsBySearchRequestWithRoomsSpec(SearchRoomsbookedsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Room)
            .Where(p => p.RoomId.Equals(request.RoomId!.Value), request.RoomId.HasValue)
            .Where(p => p.RoomRate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            .Where(p => p.RoomRate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}