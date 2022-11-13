namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomsByRoomtypeSpec : Specification<Room>, ISingleResultSpecification
{
    public RoomsByRoomtypeSpec(DefaultIdType roomtypeId) =>
        Query.Where(p => p.RoomtypeId == roomtypeId);
}
