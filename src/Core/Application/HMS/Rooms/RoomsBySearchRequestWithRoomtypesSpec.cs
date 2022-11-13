namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomsBySearchRequestWithRoomtypesSpec : EntitiesByPaginationFilterSpec<Room, RoomDto>
{
    public RoomsBySearchRequestWithRoomtypesSpec(SearchRoomsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Roomtype)
            .OrderBy(c => c.RoomNumber, !request.HasOrderBy())
            .Where(p => p.RoomtypeId.Equals(request.RoomtypeId!.Value), request.RoomtypeId.HasValue);
}