namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class RoomsbookedsByRoomSpec : Specification<Roomsbooked>
{
    public RoomsbookedsByRoomSpec(DefaultIdType roomId) =>
        Query.Where(p => p.RoomId == roomId);
}
