namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class RoomsbookedByIdWithRoomSpec : Specification<Roomsbooked, RoomsbookedDetailsDto>, ISingleResultSpecification
{
    public RoomsbookedByIdWithRoomSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Room);
}