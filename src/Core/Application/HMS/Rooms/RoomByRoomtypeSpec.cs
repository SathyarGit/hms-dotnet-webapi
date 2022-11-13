namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomByRoomtypeSpec : Specification<Room>, ISingleResultSpecification
{
    public RoomByRoomtypeSpec(int roomNumber) =>
        Query.Where(p => p.RoomNumber == roomNumber);
}