namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomByRoomNumberSpec : Specification<Room>, ISingleResultSpecification
{
    public RoomByRoomNumberSpec(int roomNumber) =>
        Query.Where(p => p.RoomNumber == roomNumber);
}