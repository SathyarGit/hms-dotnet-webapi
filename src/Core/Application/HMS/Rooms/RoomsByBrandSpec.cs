namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomsByFloorSpec : Specification<Room>
{
    public RoomsByFloorSpec(DefaultIdType floorId) =>
        Query.Where(p => p.FloorId == floorId);
}
