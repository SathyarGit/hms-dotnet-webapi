namespace FSH.WebApi.Application.HMS.Roomtypes;

public class RoomtypeByIdSpec : Specification<Roomtype, RoomtypeDto>, ISingleResultSpecification
{
    public RoomtypeByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}