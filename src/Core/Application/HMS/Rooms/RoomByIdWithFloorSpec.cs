namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomByIdWithFloorSpec : Specification<Room, RoomDetailsDto>, ISingleResultSpecification
{
    public RoomByIdWithFloorSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Floor);
}