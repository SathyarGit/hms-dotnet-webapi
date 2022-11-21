namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomsBySearchRequestWithFloorsAndRoomtypesSpec : EntitiesByPaginationFilterSpec<Room, RoomDto>
{
    public RoomsBySearchRequestWithFloorsAndRoomtypesSpec(SearchRoomsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Floor)
            .Include(p => p.Roomtype)
            .OrderBy(c => c.RoomNumber, !request.HasOrderBy())
            .Where(p => p.FloorId.Equals(request.FloorId!.Value), request.FloorId.HasValue)
            .Where(p => p.RoomtypeId.Equals(request.RoomtypeId!.Value), request.RoomtypeId.HasValue);
}